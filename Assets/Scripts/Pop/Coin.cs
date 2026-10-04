using System;
using UnityEngine;

public class Coin : MonoBehaviour, IInteractable
{

    public static event Action OnCoinCollected;
    public void Clear()
    {
    }

    public void Highlight()
    {
    }

    public void Interact()
    {
        OnCoinCollected?.Invoke();
        Destroy(gameObject);
    }
}
