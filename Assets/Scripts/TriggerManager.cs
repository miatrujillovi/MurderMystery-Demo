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
        }
    }

    #region DoorPuzzle

    private void HandleMainDoor()
    {

    }

    private void HandleNoteForDoor()
    {

    }

    #endregion DoorPuzzle

    #region FlowerpotPuzzle

    private void HandleFlowerpot()
    {

    }

    private void HandleMissingFlowerpotArea()
    {

    }

    private void HandleMissingFlowerpot()
    {

    }

    #endregion FlowerpotPuzzle

    #region LawnmowerPuzzle

    private void HandleLawenmower()
    {

    }

    private void HandleLawenmowerCode()
    {

    }

    private void HandleNotes(int _noteNumber)
    {

    }

    #endregion LawnmowerPuzzle
}
