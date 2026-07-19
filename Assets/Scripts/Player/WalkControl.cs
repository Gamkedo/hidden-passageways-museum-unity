using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class WalkControl : MonoBehaviour {
    public InputSystem_Actions inputSystem;
    private Vector2 moveInput;
    private Vector2 turnInput;

	[HideInInspector]
    public Rigidbody rb;
	private bool onGround=true;
    private Vector3 prevValidPosition;
    public bool areFeetLocked = false;
    public float jumpForce = 5.0f;
    public float walkSpeed = 6.0f;
    public float strafeSpeed = 4.0f;
    public float speedFalloffAmt = 0.9f; // friction only for lateral motion

    public float suchLowYMustHaveFallenThroughFloor = -150.0f;
    Vector3 lastKnownSafelyOnGround = Vector3.zero;

	private Vector3 forward, right;
    private float time_last_on_ground = 0;
    const float SEC_OFF_GROUND_FOR_LANDING_SOUND = 0.6f;


    //private float powerUp = 1.0f;

    public static WalkControl instance;
    public event Action OnGrounded;

	// Use this for initialization
	void Awake () {
        inputSystem = new InputSystem_Actions();
        inputSystem.Enable();
    }
    void Start() {
        lastKnownSafelyOnGround = transform.position;
        instance = this;
        rb = GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.Locked;

        if(SceneWarp.fromScene != null && SceneWarp.fromScene.Length > 0) {
            // Debug.Log("FROM SCENE: " + SceneWarp.fromScene);
            GameObject[] warpGOs = GameObject.FindGameObjectsWithTag("Teleporter");
            for (int i = 0; i < warpGOs.Length;i++) {
                SceneWarp swScript = warpGOs[i].GetComponent<SceneWarp>();
                if(swScript.sceneName == SceneWarp.fromScene) {
                    transform.position = swScript.returnLocation.position;
                    Vector3 focusFixedAtEyeHeight = swScript.transform.position;
                    focusFixedAtEyeHeight.y = transform.position.y;
                    transform.LookAt(focusFixedAtEyeHeight);
                    break;
                }
            }
        }
	}
    private void OnDestroy()
    {
        inputSystem.Disable();
    }

	void FixedUpdate()
	{
        if (ArcadePlayer.playingNow != null)
        {
            return;
        }
        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }*/

        /*if (ViewControl.instance.paperView.enabled)
        {
            rb.linearVelocity = Vector3.zero;
            return; // reading, stand still
        }*/
        if (areFeetLocked)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            if (areFeetLocked == false)
            {
				if (onGround)
				{
					forward = transform.forward;
					right = transform.right;
				}
                Vector3 lateralDecay = rb.linearVelocity;
                lateralDecay.x *= speedFalloffAmt;
                lateralDecay.z *= speedFalloffAmt;
                rb.linearVelocity = lateralDecay;
                float scaleForCompatibilityWithOlderTuning = 4.0f; // added to keep pre-physics walk tuning numbers
                rb.linearVelocity += forward * Time.deltaTime * walkSpeed * scaleForCompatibilityWithOlderTuning *
                    moveInput.y;
                rb.linearVelocity += right * Time.deltaTime * strafeSpeed * scaleForCompatibilityWithOlderTuning *
                    moveInput.x;
            }

        }
        else if (Input.GetButtonDown("Fire1"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
	}

	// Update is called once per frame
	void Update () {
        moveInput = inputSystem.Player.Move.ReadValue<Vector2>();
        turnInput = inputSystem.Player.Look.ReadValue<Vector2>();
        bool jumpKey = inputSystem.Player.Jump.WasPressedThisFrame();

        if (ArcadePlayer.playingNow != null)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }
        RaycastHit rhInfo;

        prevValidPosition = transform.position;

        if (onGround && jumpKey)
        {
            // FMODUnity.RuntimeManager.PlayOneShotAttached("event:/MainHub/JumpUp", gameObject);
            onGround = false;
            rb.linearVelocity += Vector3.up * jumpForce;
            transform.position += Vector3.up * 0.2f; // slightly cheating, helps it feel more responsive, avoids sticking back to ground
        }
        
        transform.Rotate(Vector3.up, 1.5f * turnInput.x); // reminder: don't Time.deltaTime on new mouse input, already per frame

        /*if(Input.GetKeyDown(KeyCode.Q)) {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
            return;
        }*/

        /*if (Input.GetKeyUp(KeyCode.Escape)) { // now handled by exit widget
			if(Cursor.lockState == CursorLockMode.Locked) {
				Cursor.lockState = CursorLockMode.None;
			} else {
				Cursor.lockState = CursorLockMode.Locked;
			}
		}*/

        /*if (ViewControl.instance.paperView.enabled)
        {
            return; // reading, stand still
        }*/
        /*
        if (Physics.Raycast(transform.position, Vector3.down, out rhInfo, 3.0f))
        {
			if (rhInfo.collider != null)
			{
				if (rhInfo.collider.gameObject.layer == LayerMask.NameToLayer("Water"))
				{
					transform.position = prevValidPosition; // undoing position if over water
				}
			}
        }*/

        int layerMask = ~LayerMask.GetMask("Ignore Raycast");
        if (Physics.Raycast(transform.position, Vector3.down, out rhInfo, 1.2f, layerMask))
        {
			if (rhInfo.collider != null)
			{
                if (onGround == false && rb.linearVelocity.y < 0.0f)
                {
                    if(Time.timeSinceLevelLoad - time_last_on_ground > SEC_OFF_GROUND_FOR_LANDING_SOUND)
                    {
                        OnGrounded?.Invoke();
                    }
                    // FMODUnity.RuntimeManager.PlayOneShotAttached("event:/MainHub/JumpLand", gameObject);
                }

                // Debug.Log("standing on " + rhInfo.collider.name);
				lastKnownSafelyOnGround = transform.position;
				forward = Vector3.Cross(transform.right, rhInfo.normal).normalized;
				right = Vector3.Cross(-transform.forward, rhInfo.normal).normalized;
                if (Mathf.Abs(moveInput.y) < 0.1f && Mathf.Abs(moveInput.x) < 01f &&
                    jumpKey == false)
				{
					//Magic number (1.045f) comes from the following line:
					// Debug.Log(Vector3.Distance(transform.position, rhInfo.point));
					transform.position = new Vector3(rhInfo.point.x, rhInfo.point.y + 1.045f, rhInfo.point.z);
					rb.linearVelocity = Vector3.zero;
				}
                onGround = true;
			}
        }
        else
        {
            if(onGround)
            {
                time_last_on_ground = Time.timeSinceLevelLoad;
            }
            onGround = false;
            if (transform.position.y < suchLowYMustHaveFallenThroughFloor)
            {
                Debug.Log("Fell through or off world edge, resetting to last ground touch");
                Debug.Log("If this shouldn't have happened or fell too far, set lastKnownSafelyOnGround");
                transform.position = lastKnownSafelyOnGround;
            }
        }
    }
    ///This is powerup code for Aether. Just increases jump height
    ///No idea why this isn't working right, the debug fires, but the jump force refuses to change.
    //void OnTriggerEnter(Collider col) //PowerupCode for the Aether - ties into Powerup tag. Just increases jump height.
    //{
    //    if (col.gameObject.tag == "Powerup")
    //        jumpForce += powerUp;
    //        Debug.Log("Player picked up powerup adding +" + powerUp + " to a total of " + jumpForce);
    //}

    /*
    void OnCollisionStay(Collision facts) {
		onGround = true; // currently not distinguishing ground from wall/ceiling/etc.
	}*/

	void OnTriggerStay(Collider other) {
		if(other.gameObject.layer == LayerMask.NameToLayer("Water")) {
			if(rb.linearVelocity.y < 0.0f) {
                Vector3 fixedY = rb.linearVelocity;
                fixedY.y = 0.0f;
                rb.linearVelocity = fixedY;
			}
			rb.AddForce(Vector3.up * Time.deltaTime * 1000.0f);
		}
	}
}
