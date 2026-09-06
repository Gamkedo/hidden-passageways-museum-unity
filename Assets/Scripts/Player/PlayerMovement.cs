using UnityEngine;
using UnityEngine.InputSystem;

[SelectionBase]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float walkSpeed = 5;
    [SerializeField] private float sprintSpeed = 8;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 1;
    [SerializeField] private float coyoteTimeDuration = 0.15f;
    [SerializeField] private float jumpBufferDuration = 0.15f;
    [SerializeField] private bool allowSprinting = true;

    private float coyoteTimeCounter = 0.15f;
    private float jumpBufferCounter = 0;
    private Vector3 velocity;
    InputSystem_Actions inputActions;

    private void Start()
    {
        inputActions = new();
        inputActions.Player.Enable();
        inputActions.Player.Jump.performed += Jump_performed;
    }

    private void OnDestroy()
    {
        inputActions.Player.Disable();
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        if(obj.performed)
        {
            jumpBufferCounter = jumpBufferDuration;
        }
    }

    private void Update()
    {
        if (characterController.isGrounded)
        {
            coyoteTimeCounter = coyoteTimeDuration;

            if (velocity.y < 0)
                velocity.y = -2f;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0)
        {
            jumpBufferCounter -= Time.deltaTime;
        }
        Vector2 moveInput = Vector2.zero;
        moveInput = inputActions.Player.Move.ReadValue<Vector2>();


        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            coyoteTimeCounter = 0;
            jumpBufferCounter = 0;
        }

        
        Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
        float currentSpeed= walkSpeed;
        if (allowSprinting)
        {
            currentSpeed = inputActions.Player.Sprint.inProgress ? sprintSpeed : walkSpeed;
        }


        characterController.Move(moveDirection * currentSpeed * Time.deltaTime);


        velocity.y += gravity * Time.deltaTime;

        CollisionFlags flags = characterController.Move(velocity * Time.deltaTime);

        if (flags == CollisionFlags.Above && velocity.y > 0)
        {
            velocity.y = 0;
        }
    }
}
