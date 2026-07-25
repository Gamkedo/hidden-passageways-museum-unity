using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class Orb : MonoBehaviour , IInteractable
{
    [SerializeField] private GameObject highlightObject;

    [SerializeField] private string sceneOrURL;

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
        if(sceneOrURL.Contains("https"))
        {
            Debug.Log("opening URL: " + sceneOrURL);
            OpenLink(sceneOrURL);
        } else
        {
            SceneManager.LoadScene(sceneOrURL);        
        }
    }

	public void OpenLink(string URL) {
		Application.OpenURL(URL);
	}  
}
