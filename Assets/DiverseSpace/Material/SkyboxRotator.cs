using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private float currentRotation;

    private void Update()
    {
        currentRotation -= rotationSpeed * Time.deltaTime;

        RenderSettings.skybox.SetFloat("_Rotation", currentRotation);
    }
}
