using UnityEngine;

public class RigidBodyPush : MonoBehaviour
{
    [SerializeField] private float strength = 1;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if(rb == null) return;

        if (hit.moveDirection.y < -0.3)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x,0,hit.moveDirection.z);

        rb.AddForce(pushDir * strength,ForceMode.Impulse);
    }
}
