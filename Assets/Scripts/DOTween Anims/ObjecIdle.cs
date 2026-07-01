using DG.Tweening;
using UnityEngine;

public class ObjecIdle : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform model;
    private float endPosition;
    private float startY;

    private void Awake()
    {
        if (transform.childCount > 0)
            model = transform.GetChild(0);

        startY = model.localPosition.y;
        endPosition = startY + 3f;
    }

    private void Start()
    {
        // Model moving up and down
        model.DOLocalMoveY(endPosition, speed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
