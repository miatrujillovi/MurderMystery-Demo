using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void OpenDoor()
    {
        Debug.Log("Ganaste");
    }
}
