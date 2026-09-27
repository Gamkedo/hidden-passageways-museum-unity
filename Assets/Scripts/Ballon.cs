using UnityEngine;

public class Ballon : MonoBehaviour , IInteractable
{
    [SerializeField] private float speed = 2;
    private Rigidbody rb;


    public void Clear()
    {
    }

    public void Highlight()
    {
    }

    public void Interact()
    {
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
