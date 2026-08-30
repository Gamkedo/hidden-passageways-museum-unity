using System;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour, IInteractable
{
    public static event Action OnInteractedWithSwitch;

    [SerializeField] private bool isSwitchOn = false;
    [SerializeField] private GameObject button; 

    [SerializeField] private bool isRightSwitch = false;
    public static event Action OnBulbToggleOn;
    public static event Action OnBulbToggleOff;

    public void Clear()
    {
    }

    public bool IsSwitchOn()
    {
        return isSwitchOn;
    }

    public void SetRigthSwitchValue()
    {
        isRightSwitch = true;
    }

    public void TurnOn()
    {
        isSwitchOn = true;
        button.transform.localRotation = Quaternion.Euler(-15,0,0);


        if(isRightSwitch)
        {
            OnBulbToggleOn?.Invoke();
        }
    }

  

    private void Toggle()
    {
        if(isSwitchOn)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }

    public void TurnOff()

    {
        isSwitchOn = false;
        button.transform.localRotation = Quaternion.Euler(15, 0, 0);

        if(isRightSwitch)
        {
            OnBulbToggleOff?.Invoke();
        }
    }

    public void Highlight()
    {
    }

    public void Interact()
    {
        OnInteractedWithSwitch?.Invoke();
        Toggle();
    }
}
