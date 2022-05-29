using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTargetObservation : MovementState
{
    [SerializeField] private float smoothTime;

    private Vector3 velocity = Vector3.zero;
    private CameraControl cameraControl;

    public override void Run()
    {
        Movement();
    }

    protected override void Movement()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.TransformPoint(cameraControl.CamOffset()), ref velocity, smoothTime);
    }

    protected override void ChangeState()
    {
        _cameraStateSwitch.StateSwitch<MovingTowardsTarget>();
    }

    private void Start()
    {
        cameraControl = GetComponent<CameraControl>();
        DropDownPlanet.changePlanet += ChangeTarget;
        transform.position = Vector3.zero;
    }

    private void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
        cameraControl.ResetPos();

        ChangeState();
    }
}
