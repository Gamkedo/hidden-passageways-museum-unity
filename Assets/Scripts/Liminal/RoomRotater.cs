using UnityEngine;

public class RoomRotater : MonoBehaviour
{
    [SerializeField] private Transform room;
    [SerializeField] private float speed = 10;
    [SerializeField] private BallonCollectorButton button1;
    [SerializeField] private BallonCollectorButton button2;

    private bool activateRotation = false;  
    private void Start()
    {

    }

    private void OnEnable()
    {
        button1.OnInteract += Button1_OnInteract;
        button2.OnInteract += Button2_OnInteract;
    }

    private void Button2_OnInteract()
    {
        activateRotation = false;
    }

    private void OnDisable()
    {
        button1.OnInteract -= Button1_OnInteract;
        button2.OnInteract -= Button2_OnInteract;
    }

    private void Button1_OnInteract()
    {
        activateRotation = true;
    }

    private void Update()
    {
        int x = 0;
        if (activateRotation)
            x = -90;
        else
            x = 0;

        room.rotation = Quaternion.Lerp(room.rotation, Quaternion.Euler(x,0,0), Time.deltaTime * speed);
    }
}
