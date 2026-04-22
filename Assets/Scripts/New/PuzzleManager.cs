using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace AYellowpaper.SerializedCollections
{
    public class PuzzleManager : MonoBehaviour
    {
        public static PuzzleManager instance;

        public enum Interactions
        {
            MainDoor, //hasDoorKeys -> Got the keys from both flowerpots
            NoteForDoor,
            Flowerpot,
            MissingFlowerpotArea, //isFlowerpotInPosition -> Flowerpot had to be freed + put in the area
            MissingFlowerpot, //isFlowerPotFree -> Freed flowerpot with lawnmower
            Lawnmower, //hasLawnmower -> Freed by the code
            LawnmowerCode,
            Note1,
            Note2,
            Note3,
            Note4
        }

        private bool hasDoorKeys = false;
        private bool isFlowerpotFree = false;
        private bool hasLawnmower = false;

        [Header("Informative Dialogue Settings")]
        public SerializedDictionary<Interactions, List<string>> clueDialogues;
        public SerializedDictionary<Interactions, List<string>> solvedDialogues;
        [SerializeField] private DialogueManager dialogueManager;
        [SerializeField] private DoAction actionManager;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
        }

        public void BeginInteraction(Interactions _interaction)
        {
            switch (_interaction)
            {
                case Interactions.MainDoor:
                    if (hasDoorKeys)
                    {
                        PlayerGotObject(Interactions.MainDoor);
                    } 
                    else
                    {
                        ClueInteraction(Interactions.MainDoor);
                    }
                    break;

                case Interactions.NoteForDoor:
                    ClueInteraction(Interactions.NoteForDoor);
                    break;

                case Interactions.Flowerpot:
                    ClueInteraction(Interactions.Flowerpot);
                    break;

                case Interactions.MissingFlowerpotArea:
                    if (isFlowerpotFree)
                    {
                        PlayerGotObject(Interactions.MissingFlowerpotArea);
                        actionManager.PutFlowerPot();
                        hasDoorKeys = true;
                    }
                    else
                    {
                        ClueInteraction(Interactions.MissingFlowerpotArea);
                    }
                    break;

                case Interactions.MissingFlowerpot:
                    if (hasLawnmower)
                    {
                        HandleFlowerpot().Forget();
                    }
                    else
                    {
                        ClueInteraction(Interactions.MissingFlowerpot);
                    }
                    break;

                case Interactions.Lawnmower:
                    actionManager.DisappearLawnmower();
                    hasLawnmower = true;
                    ClueInteraction(Interactions.Lawnmower);
                    break;

                case Interactions.LawnmowerCode:
                    ClueInteraction(Interactions.LawnmowerCode);
                    break;

                case Interactions.Note1:
                    ClueInteraction(Interactions.Note1);
                    break;

                case Interactions.Note2:
                    ClueInteraction(Interactions.Note2);
                    break;

                case Interactions.Note3:
                    ClueInteraction(Interactions.Note3);
                    break;

                case Interactions.Note4:
                    ClueInteraction(Interactions.Note4);
                    break;
            }
        }

        private void ClueInteraction(Interactions _clue)
        {
            foreach (var name in clueDialogues)
            {
                if (name.Key == _clue)
                {
                    dialogueManager.ShowDialogue(name.Value);
                }
            }
        }

        private void PlayerGotObject(Interactions _order)
        {
            foreach (var name in solvedDialogues)
            {
                if (name.Key == _order)
                {
                    dialogueManager.ShowDialogue(name.Value);
                }
            }
        }

        private async UniTask AsyncPlayerGotObject(Interactions _order)
        {
            foreach (var name in solvedDialogues)
            {
                if (name.Key == _order)
                {
                    await dialogueManager.AsyncShowDialogue(name.Value);
                    return;
                }
            }
        }

        private async UniTaskVoid HandleFlowerpot()
        {
            actionManager.GetFlowerpot();

            await AsyncPlayerGotObject(Interactions.MissingFlowerpot);

            actionManager.DisappearFlowerpot();

            isFlowerpotFree = true;
        }
    }
}
