using UnityEngine;

public class BallonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballonPrefab;
    [SerializeField] private GameObject goldenBallonPrefab;
    private int spawnRate = 2;


    private void Start()
    {
        InvokeRepeating(nameof(SpawnBallon),0, spawnRate);
    }

    private void SpawnBallon()
    {
        int num = Random.Range(1, 101);

        if (num < 20)
        {
            Instantiate(goldenBallonPrefab, new Vector3(Random.Range(-3, 3), Random.Range(-5, -3), Random.Range(4, 5)), Quaternion.identity, transform);

        }
        else
        {
            Instantiate(ballonPrefab, new Vector3(Random.Range(-3, 3), Random.Range(-5, -3), Random.Range(4, 5)), Quaternion.identity, transform);
        }
    }
}
