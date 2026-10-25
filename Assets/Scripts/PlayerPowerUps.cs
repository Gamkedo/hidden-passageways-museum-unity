using System.Reflection.Metadata.Ecma335;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Editor;

public class PlayerPowerUps : MonoBehaviour
{
    [SerializeField] private GameObject magnet;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            magnet.SetActive(!magnet.activeInHierarchy);
        }
    }
}
