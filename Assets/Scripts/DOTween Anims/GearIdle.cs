using UnityEngine;
using DG.Tweening;

public class GearIdle : MonoBehaviour
{
    public enum Axes
    {
        X,
        Y,
        Z
    }

    [SerializeField] private Axes axisToMove;
    [SerializeField] private float duration;

    private void Start()
    {
        switch (axisToMove)
        {
            case Axes.X:
                RotateX();
                break;

            case Axes.Y:
                RotateY();
                break;

            case Axes.Z:
                RotateZ();
                break;

            default:
                break;
        }
    }

    private void RotateX()
    {
        transform.DOLocalRotate(new Vector3(360f, 0f, 0f), duration, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    private void RotateY()
    {
        transform.DOLocalRotate(new Vector3(0f, 360f, 0f), duration, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    private void RotateZ()
    {
        transform.DOLocalRotate(new Vector3(0f, 0f, 360f), duration, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }
}
