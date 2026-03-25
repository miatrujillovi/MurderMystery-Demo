using UnityEngine;

public class FollowingUI : MonoBehaviour
{
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        transform.LookAt(target);
        transform.Rotate(0, 180f, 0);
    }
}
