using UnityEngine;

public abstract class MovementState : CameraState
{
    protected static Transform target;

    protected abstract void SetTarget(Transform newTarget);
    protected abstract void Movement();
}
