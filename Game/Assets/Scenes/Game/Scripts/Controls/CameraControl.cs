using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Чувствительность")]
    [SerializeField] private float axisSensetivity;
    [SerializeField] private float zoomSensetivity;

    [Header("Ограничения")]
    [SerializeField] private float zoomClampMin;
    [SerializeField] private float zoomClampMax;

    private float axisX = 0;
    private float axisY = 0;

    public void CameraRotate(Transform target)
    {
        transform.localEulerAngles = Rotate();

        transform.position = transform.localRotation * Zoom() + target.position;
    }

    private Vector3 Zoom()
    {
        Vector3 zoomOffset = Vector3.zero;
        zoomOffset.z += Input.GetAxis("Mouse ScrollWheel") * zoomSensetivity;
        zoomOffset.z = Mathf.Clamp(zoomOffset.z, zoomClampMin, zoomClampMax);

        return zoomOffset;
    }
    private Vector3 Rotate()
    {
        axisY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * axisSensetivity;
        axisX += Input.GetAxis("Mouse Y") * axisSensetivity;


        return new Vector3(-axisX, axisY, 0);
    }

}
