using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue Settings")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueTXT;
    [SerializeField] private PlayerMovement playerMovement;
    //[SerializeField] private bool deactivateWithTime = true;

    private bool isShowingDialogue = false;

    public async void ShowDialogue(List<string> _dialogue)
    {
        if (isShowingDialogue) return;

        isShowingDialogue = true;
        dialoguePanel.SetActive(true);
        playerMovement.enabled = false;

        await NextDialogue(_dialogue);
        isShowingDialogue = false;
    }

    private async UniTask NextDialogue(List<string> _dialogue)
    {
        for (int i = 0; i < _dialogue.Count; i++)
        {
            dialogueTXT.text = _dialogue[i];

            if (i < _dialogue.Count - 1)
            {
                await UniTask.Delay(5000);
            }
            else
            {
                await UniTask.Delay(5000);
                CloseDialogue();
            }
        }
    }

    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
        playerMovement.enabled = true;
        dialogueTXT.text = " ";
    }
}
