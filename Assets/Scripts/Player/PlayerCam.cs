using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private float sensitivityX;
    [SerializeField] private float sensitivityY;
    [SerializeField] private Transform orientation;
    [SerializeField] private float xRotation;
    [SerializeField] private float yRotation;

    private float mouseX;
    private float mouseY;

    private void Start()
    {
        /*Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;*/
    }

    private void Update()
    {
        LookInput();
        LookRotation(); 
        RotateCam();
    }

    private void LookInput()
    {
        Vector2 input = InputManager.Instance.LookingInput;

        mouseX = input.x * Time.deltaTime * sensitivityX;
        mouseY = input.y * Time.deltaTime * sensitivityY;
    }

    private void LookRotation()
    {
        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    private void RotateCam()
    {
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
