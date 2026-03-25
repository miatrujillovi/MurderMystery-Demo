using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerCam PlayerCam;
    [SerializeField] private float distanceOfUI = 2f;
    [SerializeField] private int yDistanceFromRotation = 3;

    private TextMeshProUGUI dialogueTXT;
    private GameObject dialoguePrefab;

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

    private void Start()
    {
        Transform textPanel = dialoguePanel.transform.Find("TextPanel");
        dialogueTXT = textPanel.Find("DialogueTXT").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        /*if (dialogueActive && Input.anyKeyDown)----------------------------
        {
            CloseDialogue();
        }*/
    }

    public void ShowDialogue(string _dialogue, Transform _lookAtTarget, Transform _orientation)
    {
        //Stop Player
        playerMovement.enabled = false;
        //PlayerCam.enabled = false;

        //Activate Dialogue
        ShowDialogueWindow(_lookAtTarget, _orientation);
        dialogueTXT.text = _dialogue;

        //Activate Mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        dialogueActive = true;
    }

    private void CloseDialogue()
    {
        //Deactivate Dialogue
        CloseDialogueWindow();

        //Restore Player
        playerMovement.enabled = true;
        PlayerCam.enabled = true;

        //Deactivate Mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        dialogueActive = false;
    }

    private void ShowDialogueWindow(Transform _lookAtTarget, Transform _orientation)
    {
        Vector3 orientationPosition = new Vector3(_orientation.position.x, yDistanceFromRotation, _orientation.position.z);

        Vector3 spawnPosition = orientationPosition + _orientation.forward * distanceOfUI;
        dialoguePrefab = Instantiate(dialoguePanel, spawnPosition, Quaternion.identity);

        dialoguePrefab.GetComponent<FollowingUI>().SetTarget(_lookAtTarget);
    }

    private void CloseDialogueWindow()
    {
        Destroy(dialoguePrefab);
    }
}
