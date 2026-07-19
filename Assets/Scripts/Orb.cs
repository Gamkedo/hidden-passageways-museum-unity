using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class Orb : MonoBehaviour , IInteractable
{
    [SerializeField] private GameObject highlightObject;

    [SerializeField] private string sceneName;

    private void Start()
    {
        Clear();
    }

    public void Clear()
    {
        highlightObject.gameObject.SetActive(false);
    }

    public void Highlight()
    {
        highlightObject.gameObject.SetActive(true);
    }

    public void Interact()
    {
        SceneManager.LoadScene(sceneName);
    }


    
}
