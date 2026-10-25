using System;
using Unity.Jobs;
using UnityEngine;

public class Coin : MonoBehaviour, IInteractable
{
    private Transform magnetPoint;
    private bool moveTowardMagnet = false;

    public void MoveTowardMagnet(Transform magnetTransform)
    {
        magnetPoint = magnetTransform;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        moveTowardMagnet = true;
    }

    public void AddGravity()
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        moveTowardMagnet = false;
    }

    public bool IsCoinMovingTowardMagnet()
    {
        return moveTowardMagnet;
    }

    private void Update()
    {
        if(moveTowardMagnet)
        {
            GetComponent<Rigidbody>().linearVelocity +=   (magnetPoint.position - transform.position) * 50 * Time.deltaTime;

            
        }

    }

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
