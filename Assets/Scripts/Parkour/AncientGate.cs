using UnityEngine;

public class AncientGate : MonoBehaviour
{
    [SerializeField] private GameObject stone1;

    private void Start()
    {
        stone1.gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        AncientStone.OnStoneCollected += AncientStone_OnStoneCollected;
    }

    private void OnDisable()
    {
        AncientStone.OnStoneCollected -= AncientStone_OnStoneCollected;
    }

    private void AncientStone_OnStoneCollected()
    {
        stone1.gameObject.SetActive(true);
    }
}
