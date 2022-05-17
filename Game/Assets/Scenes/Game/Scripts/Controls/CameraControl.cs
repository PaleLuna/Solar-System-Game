using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Чувствительность")]
    [SerializeField] private float axisSensetivity;
    [SerializeField] private float zoomSensetivity;

    [Header("Ограничения")]
    [SerializeField] private float zoomClampMin;
    [SerializeField] private float zoomClampMax;

    private Vector3 offset;

    private float axisX = 0;
    private float axisY = 0;


    public void Clear()
    {
        offset = Vector3.zero;
    }

    public Vector3 CameraRotate()
    {
        Zoom();

        return offset;
    }

    private void Zoom()
    {
        offset += transform.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSensetivity;
        offset = Vector3.ClampMagnitude(offset, 10);
    }
    private Vector3 Rotate()
    {
        axisY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * axisSensetivity;
        axisX += Input.GetAxis("Mouse Y") * axisSensetivity;


        return new Vector3(-axisX, axisY, 0);
    }

    private void Start()
    {
        offset = Vector3.zero;
    }
}
