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

    //INTERACTION
    private InputAction interact;
    private bool interactPressedThisFrame;
    public bool InteractPressedThisFrame => interactPressedThisFrame; //Public getter

    //CLICK
    private InputAction click;
    private bool clickPressedThisFrame;
    public bool ClickPressedThisFrame => click.WasPressedThisFrame(); //Public Getter

    private void Awake()
    {
        Instance = this;

        playerControls = new InputSystem_Actions();
        var gameplayActionMap = playerControls.Player;

        //MOVEMENT
        movement = gameplayActionMap.Move;

        //LOOKING AROUND
        looking = gameplayActionMap.Look;

        //INTERACTION
        interact = gameplayActionMap.Interact;

        //CLICK
        click = gameplayActionMap.Click;
    }

    private void OnEnable()
    {
        playerControls.Enable();

        //MOVEMENT
        movement.Enable();
        movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        movement.canceled += ctx => moveInput = Vector2.zero;

        //LOOKING AROUND
        looking.Enable();
        looking.performed += ctx => lookingInput = ctx.ReadValue<Vector2>();
        looking.canceled += ctx => lookingInput = Vector2.zero;

        //INTERACT
        interact.Enable();
        interact.performed += ctx => interactPressedThisFrame = true;

        //CLICK
        click.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        movement.Disable();
        looking.Disable();
        interact.Disable();
        click.Disable();
    }

    private void LateUpdate()
    {
        interactPressedThisFrame = false;
    }
}
