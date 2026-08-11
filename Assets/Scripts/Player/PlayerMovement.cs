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

    private float coyoteTimeCounter = 0.15f;
    private float jumpBufferCounter = 0;
    private Vector3 velocity;

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

        if (Keyboard.current.wKey.isPressed) moveInput.y += 1;
        if (Keyboard.current.sKey.isPressed) moveInput.y -= 1;
        if (Keyboard.current.aKey.isPressed) moveInput.x -= 1;
        if (Keyboard.current.dKey.isPressed) moveInput.x += 1;


        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            jumpBufferCounter = jumpBufferDuration;

        }




        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            coyoteTimeCounter = 0;
            jumpBufferCounter = 0;
        }

        moveInput.Normalize();
        Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
        float currentSpeed = Keyboard.current.leftShiftKey.isPressed ? sprintSpeed : walkSpeed;

        characterController.Move(moveDirection * currentSpeed * Time.deltaTime);


        velocity.y += gravity * Time.deltaTime;

        CollisionFlags flags = characterController.Move(velocity * Time.deltaTime);

        if (flags == CollisionFlags.Above && velocity.y > 0)
        {
            velocity.y = 0;
        }
    }
}
