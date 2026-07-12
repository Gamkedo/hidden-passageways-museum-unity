using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private WalkControl walkControl;
    [SerializeField] private AudioClip landingSound;

    private void OnEnable()
    {
        walkControl.OnGrounded += WalkControl_OnGrounded;
    }

    private void OnDisable()
    {
        walkControl.OnGrounded-= WalkControl_OnGrounded;
    }

    private void WalkControl_OnGrounded()
    {
        AudioSource.PlayClipAtPoint(landingSound,transform.position);
    }
}
