using AYellowpaper.SerializedCollections;
using UnityEngine;

public class DoAction : MonoBehaviour
{
    [Header("Lawnmower")]
    [SerializeField] private GameObject glass;
    [SerializeField] private GameObject scissors;
    [SerializeField] private TriggerEffect scissorsTrigger;
    [SerializeField] private BoxCollider scissorsCollider;
    [SerializeField] private LawnmowerLogic lawnmowerLogic;
    [Space]
    [Header("Flowerpot")]
    [SerializeField] private GameObject veins;
    [SerializeField] private GameObject flowerpot;
    [Space]
    [Header("Keys to Door")]
    [SerializeField] private GameObject newFlowerpot;

    public void GetLawnmower()
    {
        glass.SetActive(false);
        scissorsTrigger.enabled = true;
        scissorsCollider.enabled = true;
        lawnmowerLogic.enabled = false;
    }

    public void DisappearLawnmower()
    {
        scissors.SetActive(false);
        scissorsTrigger.enabled = false;
        scissorsCollider.enabled = false;
    }

    public void GetFlowerpot()
    {
        veins.SetActive(false);
    }

    public void DisappearFlowerpot()
    {
        flowerpot.SetActive(false);
    }

    public void PutFlowerPot()
    {
        newFlowerpot.SetActive(true);
    }

    public void GetKeys()
    {

    }
}
