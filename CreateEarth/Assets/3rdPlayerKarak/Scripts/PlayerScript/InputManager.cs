using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    PlayerMovements playerMovements;
    AnimatorManager animatorManager;

    // From the input manager
    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool shift_Input;
    public bool jump_Input;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerMovements = GetComponent<PlayerMovements>();
    }

    // When using mouse or keyboard to move, go to input manager
    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.Shift.performed += i => shift_Input = true;
            playerControls.PlayerActions.Shift.canceled += i => shift_Input = false;
            playerControls.PlayerActions.Jump.performed += i => jump_Input = true;
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount, playerMovements.isSprinting);
    }

    private void HandleSprintingInput()
    {
        if (shift_Input && moveAmount > 0.5f)
        {
            playerMovements.isSprinting = true;
        }
        else
        {
            playerMovements.isSprinting = false;
        }
    }

    public void HandleJumpInput()
    {
        if (jump_Input)
        {
            jump_Input = false;
            playerMovements.HandleJumping();
        }
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
        HandleJumpInput();
    }

    
}
