using UnityEngine;

public class TriggerEffect : MonoBehaviour
{
    public enum TriggerEffects {
        MainDoor,
        NoteForDoor,
        Flowerpot,
        MissingFlowerpotArea,
        MissingFlowerpot,
        Lawnmower,
        LawnmowerCode,
        Note1,
        Note2,
        Note3,
        Note4
    }

    [SerializeField] private TriggerEffects effect;
    [SerializeField] private GameObject interactUI;

    private bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            interactUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInside && InputManager.Instance.InteractPressedThisFrame)
        {
            TriggerManager.instance.ApplyEffect(effect);
        }
    }
}
