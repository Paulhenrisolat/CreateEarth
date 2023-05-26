using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Animator animator;
    InputManager inputManager;
    CameraManager cameraManager;
    PlayerMovements playerMovements;

    public bool isInteracting;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        playerMovements = GetComponent<PlayerMovements>();
    }
    
    private void Update()
    {
        inputManager.HandleAllInputs(); // call the method who andle all input method
    }

    private void FixedUpdate()
    {
        playerMovements.HandleAllMovements(); // call the method who andle all movement method
    }

    // start after a frame end
    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement(); // call the method who andle all camera method

        isInteracting = animator.GetBool("isInteracting");
        playerMovements.isJumping = animator.GetBool("isJumping");
        animator.SetBool("isGrounded", playerMovements.isGrounded);
    }
}
