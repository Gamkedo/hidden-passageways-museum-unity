using UnityEngine;

public class BallonCollector : MonoBehaviour
{
    [SerializeField] private BallonCollectorButton collectorButton;
    [SerializeField] private GameObject collectorShade;


    private void OnEnable()
    {
        collectorButton.OnInteract += CollectorButton_OnInteract;
    }

    private void OnDisable()
    {
        collectorButton.OnInteract -= CollectorButton_OnInteract;
    }

    private void CollectorButton_OnInteract()
    {
        collectorShade.SetActive(!collectorShade.activeInHierarchy);
    }
}
