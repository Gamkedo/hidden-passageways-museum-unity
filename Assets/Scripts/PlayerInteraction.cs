using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private IInteractable component;
    [SerializeField] private InputActionReference interact;
    [SerializeField] private Transform camera;
    [SerializeField] private float interactionDistance = 3;

    private void OnEnable()
    {
        interact.action.started += Action_started;
    }

    private void Update()
    {
        if (Physics.Raycast(camera.transform.position, camera.forward, out RaycastHit hitInfo, interactionDistance))
        {
            if (hitInfo.collider.TryGetComponent<IInteractable>(out component))
            {
                component.Highlight();
            }
        }
        else
        {
            if (component != null)
            {
                component.Clear();
                component = null;
            }
        }
    }

    private void OnDisable()
    {
        interact.action.started -= Action_started;
    }

    private void Action_started(InputAction.CallbackContext obj)
    {
        if(Physics.Raycast(camera.transform.position,camera.forward,out RaycastHit hitInfo, interactionDistance))
        {
            if(hitInfo.collider.TryGetComponent<IInteractable>(out IInteractable component))
            {
                component.Interact();
            }
        }

    }
}
