using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private InputSystem_Actions playerControls;

    //MOVEMENT
    private InputAction movement;
    private Vector2 moveInput;
    public Vector2 MoveInput => moveInput; // Public getter

    //LOOKING AROUND
    private InputAction looking;
    private Vector2 lookingInput;
    public Vector2 LookingInput => lookingInput; // Public getter

    private void Awake()
    {
        Instance = this;

        playerControls = new InputSystem_Actions();
        var gameplayActionMap = playerControls.Player;

        //MOVEMENT

        movement = gameplayActionMap.Move;
        //LOOKING AROUND
        looking = gameplayActionMap.Look;
    }

    private void OnEnable()
    {
        //MOVEMENT
        movement.Enable();
        movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        movement.canceled += ctx => moveInput = Vector2.zero;

        //LOOKING AROUND
        looking.Enable();
        looking.performed += ctx => lookingInput = ctx.ReadValue<Vector2>();
        looking.canceled += ctx => lookingInput = Vector2.zero;
    }

    private void OnDisable()
    {
        movement.Disable();
        looking.Disable();
    }
}
