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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerManager.instance.ApplyEffect(effect);
        }
    }
}
