using System;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public static TriggerManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ApplyEffect(TriggerEffect.TriggerEffects _effect)
    {
        switch (_effect)
        {
            case TriggerEffect.TriggerEffects.MainDoor:
                HandleMainDoor(); 
                break;

            case TriggerEffect.TriggerEffects.NoteForDoor:
                HandleNoteForDoor();
                break;

            case TriggerEffect.TriggerEffects.Flowerpot:
                HandleFlowerpot();
                break;

            case TriggerEffect.TriggerEffects.MissingFlowerpotArea:
                HandleMissingFlowerpotArea();
                break;

            case TriggerEffect.TriggerEffects.MissingFlowerpot:
                HandleMissingFlowerpot();
                break;

            case TriggerEffect.TriggerEffects.Lawnmower:
                HandleLawenmower();
                break;

            case TriggerEffect.TriggerEffects.LawnmowerCode:
                HandleLawenmowerCode();
                break;

            case TriggerEffect.TriggerEffects.Note1:
                HandleNotes(1);
                break;

            case TriggerEffect.TriggerEffects.Note2:
                HandleNotes(2);
                break;

            case TriggerEffect.TriggerEffects.Note3:
                HandleNotes(3);
                break;

            case TriggerEffect.TriggerEffects.Note4:
                HandleNotes(4);
                break;
        }
    }

    #region DoorPuzzle

    private void HandleMainDoor()
    {
        Debug.Log("The door is locked. I need to get inside");
    }

    private void HandleNoteForDoor()
    {
        Debug.Log("I left the keys under the flowerpot - Martha.");
    }

    #endregion DoorPuzzle

    #region FlowerpotPuzzle

    private void HandleFlowerpot()
    {
        Debug.Log("A flowerpot.");
        Debug.Log("It doesn't seem to have a key under.");
    }

    private void HandleMissingFlowerpotArea()
    {
        Debug.Log("There seems to be something missing here...");
    }

    private void HandleMissingFlowerpot()
    {
        Debug.Log("This is completly trapped by those veins.");
        Debug.Log("Maybe I can use that lawnmower.");
    }

    #endregion FlowerpotPuzzle

    #region LawnmowerPuzzle

    private void HandleLawenmower()
    {
        Debug.Log("Can only be opened with the code.");
    }

    private void HandleLawenmowerCode()
    {
        Debug.Log("Maybe something related to the order of the code.");
    }

    private void HandleNotes(int _noteNumber)
    {
        switch (_noteNumber)
        {
            case 1:
                Debug.Log("Lirio = 0");
                break;

            case 2:
                Debug.Log("Girasol = 3");
                break;

             case 3:
                Debug.Log("Rosa = 8");
                break;

             case 4:
                Debug.Log("Tulipan = 6");
                break;
        }
    }

    #endregion LawnmowerPuzzle
}
