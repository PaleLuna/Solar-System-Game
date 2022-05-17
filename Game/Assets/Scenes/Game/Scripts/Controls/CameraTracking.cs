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

        cameraControl.SetNewTarget();
    }

    private void Start()
    {
        transform.position = Vector3.zero;
        cameraControl = GetComponent<CameraControl>();
        
        SetNewTarget(target);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.TransformPoint(cameraControl.CamOffset()), ref velocity, smoothTime);
    }
}
