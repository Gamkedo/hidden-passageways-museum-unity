using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioClip landingSound;
    [SerializeField] private float airTimeRequiredForLandSound = .4f;
    private bool isGrounded;
    private bool wasGroundedLastFrame;
    private float inAirTimeCurrent;
     private CharacterController characterController;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = characterController.isGrounded;
        if ((isGrounded && !wasGroundedLastFrame) && inAirTimeCurrent >= airTimeRequiredForLandSound)
        {
            AudioSource.PlayClipAtPoint(landingSound, transform.position);

        }

        if (isGrounded)
        {
            inAirTimeCurrent = 0;

        }
        else
        {
            inAirTimeCurrent += Time.deltaTime;
        }

        wasGroundedLastFrame = isGrounded;
    }
}
