using System;
using UnityEngine;

public class EndSwitch : MonoBehaviour, IInteractable
{
    public static event Action OnEndSwitchInteract;

    public void Clear()
    {
    }

    public void Highlight()
    {
    }

    public void Interact()
    {
        OnEndSwitchInteract?.Invoke();
    }
}
