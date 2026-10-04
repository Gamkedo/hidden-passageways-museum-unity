using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private int coinCount = 0; 

    [SerializeField] private TextMeshProUGUI coinCountText;

    private void OnEnable()
    {
        Coin.OnCoinCollected += Coin_OnCoinCollected;
    }

    private void Coin_OnCoinCollected()
    {
        coinCount++;
        coinCountText.text = "Coin: "+ coinCount.ToString();
    }

    private void OnDisable()
    {
        Coin.OnCoinCollected -= Coin_OnCoinCollected;
    }

}
