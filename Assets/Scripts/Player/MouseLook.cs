using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float mouseSensitivity = 0.1f;

    private float xRotation = 0;
    InputSystem_Actions inputActions;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        inputActions = new();
        inputActions.Player.Enable();
    }


    private void OnDestroy()
    {
        inputActions.Player.Disable();

    }
    private void Update()
    {
        Vector2 lookDelta = inputActions.Player.Look.ReadValue<Vector2>();
        float mouseX = lookDelta.x * mouseSensitivity;
        float mouseY = lookDelta.y * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}