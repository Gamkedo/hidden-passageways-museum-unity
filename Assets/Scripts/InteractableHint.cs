using UnityEngine;

public class InteractableHint : MonoBehaviour
{
    [SerializeField] private GameObject hintVisual;

    private void Start()
    {
        hintVisual.SetActive(false);
    }

    public void OnZoneEnter(ColliderType type)
    {
        if (type == ColliderType.INNER)
        {
            hintVisual.SetActive(false);
        }else if (type == ColliderType.OUTER)
        {
            hintVisual.SetActive(true);
        }
    }

    public void OnZoneExit(ColliderType type)
    {
        if (type == ColliderType.INNER)
        {
            hintVisual.SetActive(true);
        }
        else if (type == ColliderType.OUTER)
        {
            hintVisual.SetActive(false);
        }
    }
}
