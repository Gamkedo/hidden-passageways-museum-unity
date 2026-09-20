using UnityEngine;

public class Ballon : MonoBehaviour , IInteractable
{
    [SerializeField] private float speed = 2;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
