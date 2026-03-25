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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.SetActive(true);
            /*if ()
            {
                TriggerManager.instance.ApplyEffect(effect);
            }*/
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.SetActive(false);
        }
    }
}
