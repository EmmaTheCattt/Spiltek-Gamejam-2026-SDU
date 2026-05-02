using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Purple_Guy_Input_Manager : MonoBehaviour
{
    public static Vector2 movement;
    public static bool jumpWasPressed;
    public static bool jumpIsHeld;
    public static bool jumpIsReleased;
    private InputAction moveAction;
    private InputAction jumpAction;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    private void Update()
    {
        movement = moveAction.ReadValue<Vector2>();
        Debug.Log(movement);
        jumpWasPressed = jumpAction.WasPressedThisFrame();
        jumpIsHeld = jumpAction.IsPressed();
        jumpIsReleased = jumpAction.WasReleasedThisFrame();
        SignalCheck();
    }
    private void SignalCheck()
    {
        if(movement.x != Vector2.zero.x|| movement.y != Vector2.zero.y)
        {
            Debug.Log("Signal Sent");
        }
    }
}