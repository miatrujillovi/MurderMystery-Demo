using UnityEngine;

public class LimitFramRate : MonoBehaviour
{
    [Header("Device Settings")]
    [SerializeField] private bool androidVer;

    void Awake()
    {
        QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.

        if (androidVer)
        {
            Application.targetFrameRate = 30;
        }
        else
        {
            Application.targetFrameRate = 60;
        }
    }
}
