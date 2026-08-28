using TMPro;
using UnityEngine;

public class escalator : MonoBehaviour
{
    public Vector3 offset;
    public float speed = 5f;
    private Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPos+offset, speed * Time.deltaTime);
        if (transform.position == startPos+offset)
        {
            transform.position = startPos;
        }
    }
}
