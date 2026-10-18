using System;
using TMPro;
using Unity.Jobs;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private int coinCount = 0; 

    [SerializeField] private TextMeshProUGUI coinCountText;

    public static event Action<int> OnCoinCollected;

    private void OnEnable()
    {
        Coin.OnCoinCollected += Coin_OnCoinCollected;
    }

    public void Purchase(int amount)
    {
        if(coinCount >= amount)
        {
            coinCount -= amount;
        }
        UpdateCoinCountText();
    }


    private void Coin_OnCoinCollected()
    {
        coinCount++;
        UpdateCoinCountText();
        OnCoinCollected?.Invoke(coinCount);
    }

    private void UpdateCoinCountText()
    {
        coinCountText.text = "Coin: "+ coinCount.ToString();
    }

    private void OnDisable()
    {
        Coin.OnCoinCollected -= Coin_OnCoinCollected;
    }

}
