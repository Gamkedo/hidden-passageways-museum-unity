using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool timerStop = false;
    [SerializeField] private TextMeshProUGUI timerText;
    float timer = 0f;

    private void OnEnable()
    {
        Bulb.OnGameWon += Bulb_OnGameWon;
    }

    private void OnDestroy()
    {
        Bulb.OnGameWon -= Bulb_OnGameWon;
    }

    private void Bulb_OnGameWon()
    {
        timerStop = true;
        timerText.text = "Your time : " + Convert.ToInt16(timer).ToString();
    }

    private void Update()
    {
        if(!timerStop)
        {
         timer += Time.deltaTime;
        timerText.text = Convert.ToInt16(timer).ToString();

        }
    }
}
