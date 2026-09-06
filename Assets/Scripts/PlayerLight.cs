using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private Light light;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.GetComponent<LightOrb>())
        {
            Destroy(hit.gameObject);
            light.range += 1;
        }
    }
}
