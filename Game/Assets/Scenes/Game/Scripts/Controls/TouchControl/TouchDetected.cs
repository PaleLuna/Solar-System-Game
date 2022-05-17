using UnityEngine;

public class TouchDetected : MonoBehaviour
{
    public delegate void Touch(float x, float y);
    public static event Touch touch;

    [SerializeField] private float Sensetivity;

    private Vector2 startPos;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            startPos = cam.ScreenToViewportPoint(Input.mousePosition);
        else if(Input.GetMouseButton(0))
        {
            float axisX = (cam.ScreenToViewportPoint(Input.mousePosition).x - startPos.x);
            float axisY = (cam.ScreenToViewportPoint(Input.mousePosition).y - startPos.y);

            touch?.Invoke(axisX * Time.deltaTime, axisY * Time.deltaTime);
        }

    }
}
