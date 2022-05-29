using UnityEngine;

public class CameraControl : MonoBehaviour
{
	[Header("Параметры вращения")]
	[SerializeField] private float mouseSensetivity;
	[SerializeField] private float axisYLimit;

	[Header("Параметры \"Zoom\"")]
	[SerializeField] private float zoomSensetivity;
	[SerializeField] private float minZoom;
	[SerializeField] private float maxZoom;

	private Vector3 pos;
	private Vector3 rotation;
	private float axisX = 0;
	private float axisY = 0;

	public void ResetPos()
    {
		pos = Vector3.zero;
		rotation = Vector3.zero;

		axisX = 0;
		axisY = 0;
	}

	public Vector3 CamOffset()
    {
		Zoom();
		transform.localEulerAngles = rotation;
		
		return transform.localRotation * pos;
    }
	private void Zoom()
	{
		pos.z += Input.GetAxis("Mouse ScrollWheel") * zoomSensetivity;
		pos.z = Mathf.Clamp(pos.z, -Mathf.Abs(maxZoom), -Mathf.Abs(minZoom));
	}
	private void Rotation(float axisX, float axisY)
    {
		this.axisX += axisY * mouseSensetivity;
		this.axisX = Mathf.Clamp(this.axisX, -axisYLimit, axisYLimit);
		this.axisY = transform.localEulerAngles.y + axisX * mouseSensetivity;

		rotation = new Vector3(this.axisX, this.axisY, 0);
	}

    private void Start()
    {
		rotation = Vector3.zero;
		TouchDetected.touch += Rotation;

		pos = Vector3.zero;

		axisY = Mathf.Abs(axisY);
		axisY = (axisYLimit > 90 ? axisYLimit : 90);
    }
}
