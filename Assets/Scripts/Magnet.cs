using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private Transform magnetPoint;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Coin>(out Coin coin))
        {
            if(!coin.IsCoinMovingTowardMagnet())
            coin.MoveTowardMagnet(magnetPoint);
        }
    }


    private void OnDisable()
    {
        Coin[] coins = FindObjectsByType<Coin>();

        foreach (Coin coin in coins)
        {
            coin.AddGravity();
        }
    }

}
