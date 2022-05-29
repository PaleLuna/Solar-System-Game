using UnityEngine;

public abstract class MovementState : CameraState
{
    protected static Transform target;

    protected abstract void Movement();
    
}
