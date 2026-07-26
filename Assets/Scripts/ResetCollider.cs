using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetCollider : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("reset collider trigger from " + gameObject.name + " touched by " + other.name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
