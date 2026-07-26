using System;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private string id;
    public static event Action<string> OnItemCollect;
    public void Clear()
    {
    }

    public void Highlight()
    {
    }

    public void Interact()
    {
        OnItemCollect?.Invoke(id);
        Destroy(gameObject);
    }
}
