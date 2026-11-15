using System;
using UnityEngine;

public class AncientStone : MonoBehaviour , IInteractable
{
    public static event Action OnStoneCollected;

    public void Clear()
    {
    }

    public void Highlight()
    {
    }

    public void Interact()
    {
        OnStoneCollected?.Invoke();
        Destroy(gameObject);
    }

   
}
