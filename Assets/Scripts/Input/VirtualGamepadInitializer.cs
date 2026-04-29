using UnityEngine;
using UnityEngine.InputSystem;

public class VirtualGamepadInitializer : MonoBehaviour
{
    private void Awake()
    {
        if (Gamepad.current == null)
        {
            InputSystem.AddDevice<Gamepad>();
        }
    }
}
