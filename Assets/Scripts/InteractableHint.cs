using UnityEngine;

public class InteractableHint : MonoBehaviour
{
    [SerializeField] private GameObject hintVisual;
    public static bool locked = false; 

    private void Start()
    {
        hintVisual.SetActive(false);
    }

    public void OnZoneEnter(ColliderType type)
    {
        if (locked)
            return;
        if (type == ColliderType.INNER)
        {
            hintVisual.SetActive(false);
        }else if (type == ColliderType.OUTER)
        {
            hintVisual.SetActive(true);
        }
    }

    public void ShowHintVisual()
    {
        hintVisual.SetActive(true);
    }

    public void HideHintVisual()
    {
        hintVisual.SetActive(false);
    }

    public void OnZoneExit(ColliderType type)
    {
        if (locked)
            return;
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
