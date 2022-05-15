using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    [SerializeField] private Vector3 targetPosition;

    private Vector3 velocity = Vector3.zero;
    private CameraControl cameraControl;

    public void SetNewTarget(Transform target)
    {
        this.target = target;
        transform.LookAt(target);
    }

    private void Start()
    {
        cameraControl = GetComponent<CameraControl>();
        SetNewTarget(target);
    }

    private void FixedUpdate()
    {
        /*if (cameraControl)
            cameraControl.CameraRotate(target);*/
        transform.position = Vector3.SmoothDamp(transform.position, target.TransformPoint(targetPosition), ref velocity, smoothTime);
        transform.LookAt(target);
    }
}
