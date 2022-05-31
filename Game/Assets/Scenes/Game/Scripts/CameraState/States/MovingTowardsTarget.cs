using UnityEngine;

public class MovingTowardsTarget : MovementState
{
    [SerializeField] private float timeToTrevelInSeconds;
    [SerializeField] private float offset;

    private float startTime;
    private float fracComplete;
    private Vector3 startPosition;
    private Vector3 targetPos;

    public override void Run()
    {
        Movement();
    }
    protected override void Movement()
    {
        if (fracComplete >= 1)
            ChangeState();

        fracComplete = ((Time.time - startTime) / timeToTrevelInSeconds);

        transform.position = Vector3.Lerp(startPosition, target.TransformPoint(targetPos), fracComplete);
        transform.LookAt(target);
    }

    protected override void SetTarget(Transform newTarget)
    {
        target = newTarget;

        startTime = Time.time;
        fracComplete = 0.0F;

        transform.LookAt(target);
        startPosition = transform.position;
        targetPos = target.transform.forward * -offset;
    }
    protected override void ChangeState()
    {
        _cameraStateSwitch.StateSwitch<CamTargetObservation>();
    }

    private void Start()
    {
        DropDownPlanet.changePlanet += SetTarget;
    }
}
