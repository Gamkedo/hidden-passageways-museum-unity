using TMPro;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private GameObject ballonCollector;
    [SerializeField] private TextManager textManager;
    [SerializeField] private int ballonCollectorCost = 10;
    [SerializeField] private GameObject goalUI;


    private void OnEnable()
    {
        TextManager.OnCoinCollected += TextManager_OnCoinCollected;
    }

    private void OnDisable()
    {
        TextManager.OnCoinCollected += TextManager_OnCoinCollected;
    }

    private void TextManager_OnCoinCollected(int count)
    {
        if(count>=ballonCollectorCost)
        {
        textManager.Purchase(ballonCollectorCost);

        ballonCollector.SetActive(true);
            goalUI.gameObject.SetActive(false);
        }
    }
}
