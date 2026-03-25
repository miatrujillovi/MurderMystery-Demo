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

    [Header("Effect that the trigger will have")]
    [SerializeField] private TriggerEffects effect;
    [Space]
    [Header("Spacial UI Rotation")]
    [SerializeField] private GameObject interactUI;
    [SerializeField] private float distanceOfUI = 2.5f;
    [SerializeField] private int yDistanceFromRotation = 3;
    [SerializeField] private Transform uiLookAtTarget;


    private bool playerInside = false;
    private GameObject prefabUI;
    private GameObject player;
    private Transform orientation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            orientation = other.transform.Find("Orientation");

            playerInside = true;
            interactUI.SetActive(true);
            ShowInteractUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            interactUI.SetActive(false);
            CloseInteractUI();
        }
    }

    private void ShowInteractUI()
    {
        Vector3 orientationPosition = new Vector3(orientation.position.x, yDistanceFromRotation, orientation.position.z);

        Vector3 spawnPosition = orientationPosition + orientation.forward * distanceOfUI;
        prefabUI = Instantiate(interactUI, spawnPosition, Quaternion.identity);

        prefabUI.GetComponent<FollowingUI>().SetTarget(uiLookAtTarget);
    }

    private void CloseInteractUI()
    {
        Destroy(prefabUI);
    }

    private void Update()
    {
        //DETENER E DE SER PRESIONADA OTRA VEZ PARA LA FUNCION-----------------------------------------------
        if (playerInside && InputManager.Instance.InteractPressedThisFrame)
        {
            TriggerManager.instance.ApplyEffect(effect, uiLookAtTarget, orientation);
            CloseInteractUI();
        }
    }
}
