using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;

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
        DropDownPlanet.changePlanet += SetNewTarget;
        transform.position = Vector3.zero;
        cameraControl = GetComponent<CameraControl>();
        
        SetNewTarget(target);
    }

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.TransformPoint(cameraControl.CamOffset()), ref velocity, smoothTime);
    }
}
