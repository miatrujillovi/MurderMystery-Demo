using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject interactPanel;
    [SerializeField] private TextMeshProUGUI dialogueTXT;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerCam PlayerCam;

    private bool dialogueActive = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (dialogueActive && Input.anyKeyDown)
        {
            CloseDialogue();
        }
    }

    public void ShowDialogue(string _dialogue)
    {
        //Stop Player
        playerMovement.enabled = false;
        PlayerCam.enabled = false;

        //Activate Dialogue
        dialoguePanel.SetActive(true);
        interactPanel.SetActive(false);
        dialogueTXT.text = _dialogue;

        //Activate Mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        dialogueActive = true;
    }

    private void CloseDialogue()
    {
        //Deactivate Dialogue
        dialoguePanel.SetActive(false);
        dialogueTXT.text = " ";

        //Restore Player
        playerMovement.enabled = true;
        PlayerCam.enabled = true;

        //Deactivate Mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        dialogueActive = false;
    }
}
