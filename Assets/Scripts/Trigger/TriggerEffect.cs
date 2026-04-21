using AYellowpaper.SerializedCollections;
using UnityEngine;

public class TriggerEffect : MonoBehaviour
{
    [Header("Trigger Settings")]
    [SerializeField] private PuzzleManager.Interactions interaction;
    [SerializeField] private GameObject interactUI;

    private bool isPlayerInside;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            interactUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerInside && InputManager.Instance.InteractPressedThisFrame)
        {
            PuzzleManager.instance.BeginInteraction(interaction);
            interactUI.SetActive(false);
        }
    }
}
