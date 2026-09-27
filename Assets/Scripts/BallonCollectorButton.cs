using System;
using UnityEngine;

public class BallonCollectorButton : MonoBehaviour, IInteractable
{
    public event Action OnInteract;

    public void Clear()
    {

    }

    public void Highlight()
    {

    }

    public void Interact()
    {
        OnInteract?.Invoke();
    }
}
