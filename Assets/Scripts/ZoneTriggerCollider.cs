using UnityEngine;

public enum ColliderType
{
    INNER,
    OUTER
}
public class ZoneTriggerCollider : MonoBehaviour
{
    [SerializeField] private InteractableHint interactableHint;
    [SerializeField] private ColliderType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
            interactableHint.OnZoneEnter(type);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<PlayerMovement>())
            interactableHint.OnZoneExit(type);

    }
}
