using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vision : MonoBehaviour
{
    [SerializeField] private InputActionReference reference;
    [SerializeField] private float duration = 5;

    private void OnEnable()
    {
        reference.action.started += Action_started;

    }
    InteractableHint[] interactableHints;
    private void Start()
    {
        interactableHints =  FindObjectsByType<InteractableHint>();
    }

    private void OnDisable()
    {
        reference.action.started -= Action_started;
    }

    private void Action_started(InputAction.CallbackContext context)
    {
        StartCoroutine(ShowallHint());
    }


    IEnumerator ShowallHint()
    {
        foreach (InteractableHint item in interactableHints)
        {
            InteractableHint.locked = true;
            item.ShowHintVisual();
        }

        yield return new WaitForSeconds(duration);

        foreach (InteractableHint item in interactableHints)
        {
            InteractableHint.locked = false;
            item.HideHintVisual();
        }

    }

}
