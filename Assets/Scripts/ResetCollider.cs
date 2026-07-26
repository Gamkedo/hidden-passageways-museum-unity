using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetCollider : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        WalkControl wcScript = other.GetComponentInParent<WalkControl>();
        if(wcScript) // should only react to player
        {
            Debug.Log("reset collider trigger from " + gameObject.name + " touched by " + other.name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
        } else
        {
            Debug.Log("non-player fell from stage " + gameObject.name + " look for: " + other.name);
        }

    }
}
