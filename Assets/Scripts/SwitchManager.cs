using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchManager : MonoBehaviour
{
    [SerializeField] private List<Switch> switches;
    private int allowedSwitchCount = 1;
    [SerializeField] private int switchOncount = 0;
    [SerializeField] private Transform startA;
    [SerializeField] private Transform startB;
    [SerializeField] private int switchToSpawn;
    [SerializeField] private GameObject switchPrefab;

    private void OnEnable()
    {
        Switch.OnInteractedWithSwitch += Switch_OnBulbToggle;
    }



    private void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            allowedSwitchCount = 2;
        }
    }

    private void Start()
    {
        for (int i = 0; i < switchToSpawn; i++)
        {
               Switch switchObject =  Instantiate(switchPrefab, 
                    new Vector3(0,Random.Range(startA.position.y, startB.position.y),
                    Random.Range(startA.position.z, startB.position.z)), Quaternion.Euler(0,-90,0)).GetComponent<Switch>();



        switches.Add(switchObject);
        }

        switches[ Random.Range(0, switches.Count)].SetRigthSwitchValue();
    }

    private void Switch_OnBulbToggle()
    {
        switchOncount = 0;
        for (int i = 0; i < switches.Count; i++)
        {
            if (switches[i].IsSwitchOn())
                switchOncount++;

        }
        if (switchOncount >= allowedSwitchCount)


        {
            for (int i = 0; i < switches.Count; i++)
            {

                switches[i].TurnOff();

            }

        }

        


    }

    private void OnDisable()
    {
        Switch.OnInteractedWithSwitch -= Switch_OnBulbToggle;
    }

}
