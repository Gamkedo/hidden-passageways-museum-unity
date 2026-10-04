using UnityEngine;

public enum BallonType
{
    RED,
    GOLDEN
}
public class Ballon : MonoBehaviour , IInteractable
{
    [SerializeField] private BallonType type = BallonType.RED;
    [SerializeField] private float speed = 2;
    [SerializeField] private GameObject coinPrefab;
    private Rigidbody rb;


    public void Clear()
    {
    }

    public void Highlight()
    {
    }

    public void Interact()
    {
        Rigidbody rb = Instantiate(coinPrefab,transform.position,Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 5,ForceMode.Impulse);
        rb.AddTorque(new Vector3(Random.Range(0,2), Random.Range(0, 2), Random.Range(0, 2)) * 0.25f,ForceMode.Impulse);


        if (type == BallonType.GOLDEN)
        {
            Rigidbody rb1 = Instantiate(coinPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb1.AddForce(Vector3.up * 5, ForceMode.Impulse);
            rb1.AddTorque(new Vector3(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2)) * 0.25f, ForceMode.Impulse);
        }
            Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity += Vector3.up * speed * Time.deltaTime;
    }
}
