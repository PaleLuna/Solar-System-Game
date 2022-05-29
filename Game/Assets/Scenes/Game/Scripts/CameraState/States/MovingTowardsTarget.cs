using UnityEngine;

public class MovingTowardsTarget : MovementState
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 offset;
    private float step = 0.0F;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public override void Run()
    {
        Movement();
    }

    protected override void Movement()
    {
        if (step > 1)
            ChangeState();

        transform.position = Vector3.Slerp(transform.position, target.TransformPoint(offset), step);
        transform.LookAt(target);
        step += Time.deltaTime;
    }
    protected override void ChangeState()
    {
        step = 0;
        _cameraStateSwitch.StateSwitch<CamTargetObservation>();
    }
}
