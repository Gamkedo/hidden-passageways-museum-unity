using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class StoneDropper : MonoBehaviour
{
    [SerializeField] private InputActionReference interact;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject stonePrefab;
    private float currentScale = 0.1f;

    private void OnEnable()
    {
        interact.action.started += Action_started;
    }

    private void Action_started(InputAction.CallbackContext context)
    {
        GameObject stone =  Instantiate(stonePrefab,spawnPoint.position,Quaternion.identity);
        currentScale -= 0.001f;
        currentScale =  Mathf.Clamp(currentScale, 0.005f,0.1f);
        stone.transform.localScale = new Vector3(currentScale,currentScale,currentScale);
    }

    private void OnDisable()
    {
        interact.action.started -= Action_started;
    }
}
