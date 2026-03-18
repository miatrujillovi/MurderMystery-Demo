using UnityEngine;

public class LimitFramRate : MonoBehaviour
{
    [SerializeField] private int targetFrameRate = 30;

    void Start()
    {
        QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
        Application.targetFrameRate = targetFrameRate;
    }
}
