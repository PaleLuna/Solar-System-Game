using UnityEngine;

public abstract class CameraState : MonoBehaviour
{
    protected ICameraStateSwitch _cameraStateSwitch;

    public virtual void Init(ICameraStateSwitch cameraStateSwitch)
    {
        _cameraStateSwitch = cameraStateSwitch;
    }

    public abstract void Run();
    protected abstract void ChangeState();
}
