using UnityEngine;

public class FollowingEnemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    private void Update()
    {

        Vector3 dir = (transform.position - Camera.main.transform.position).normalized ;

        float dot = Vector3.Dot(Camera.main.transform.forward,dir);
        if(dot < 0.5f )
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        Debug.Log(dir);
    }
}
