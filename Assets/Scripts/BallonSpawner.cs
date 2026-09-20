using UnityEngine;

public class BallonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballonPrefab;


    private void Start()
    {
        InvokeRepeating(nameof(SpawnBallon),2,5);
    }

    private void SpawnBallon()
    {
        Instantiate(ballonPrefab,new Vector3(Random.Range(-3,3), Random.Range(-5, -3), Random.Range(4, 5)),Quaternion.identity,transform);
    }
}
