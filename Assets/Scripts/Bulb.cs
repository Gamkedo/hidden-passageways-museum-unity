using System;
using UnityEngine;

public class Bulb : MonoBehaviour
{
    public static event Action OnGameWon;
    private bool isBulbOn = false;

    [SerializeField] private Light light;
    [SerializeField] private MeshRenderer bulb;

    private void OnEnable()
    {
        Switch.OnBulbToggleOn += Switch_OnBulbOn;
        Switch.OnBulbToggleOff += Switch_OnBulbToggleOff;
        EndSwitch.OnEndSwitchInteract += EndSwitch_OnEndSwitchInteract;
    }

    private void EndSwitch_OnEndSwitchInteract()
    {
        if (isBulbOn)
        {
            OnGameWon?.Invoke();
        }
    }

    private void Switch_OnBulbToggleOff()
    {
        TurnOff();
    }

    private void Start()
    {
        TurnOff();
    }

    private void Switch_OnBulbOn()
    {
        TurnOn();
    }

    private void OnDisable()
    {
        Switch.OnBulbToggleOn -= Switch_OnBulbOn;
        Switch.OnBulbToggleOff -= Switch_OnBulbToggleOff; ;
        EndSwitch.OnEndSwitchInteract -= EndSwitch_OnEndSwitchInteract;
    }

    public void TurnOn()
    {
        light.intensity = 0.18f;
        isBulbOn = true;
        bulb.material.EnableKeyword("_EMISSION");
    }


    public  void Toggle()
    {
        if (isBulbOn)
        {
            TurnOff();
        }

        else
        {
            TurnOn();
        }
    }


    public void TurnOff() {

        bulb.material. DisableKeyword("_EMISSION");
        light.intensity = 0;
        isBulbOn = false;
    }
}
