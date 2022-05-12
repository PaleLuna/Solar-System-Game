using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Celestial : MonoBehaviour
{
    [Header("Физические характеристики")]
    [SerializeField] private bool isMoving;
    [SerializeField] private float mass;
    [SerializeField] private float radius;

    [Header("Параметры орбиты")]
    [SerializeField] private float distanceFromTheSun;
    [SerializeField] private float orbitalInclinationInDegrees;

    [Header("Параметры вращение вокруг оси")]
    [SerializeField] private float rotaryAxisTilt;
    [SerializeField] private float rotationVelocity;

    [Header("Необходимые компоненты")]
    private Rigidbody thisRigidbody;
    private Transform planetTransform;

    public float Mass
    {
        get { return mass; }
    }
    public Rigidbody ThisRigidbody
    {
        get { return thisRigidbody; }
    }

    public void MoveWithGravity(Celestial other, float G)
    {
        float r = Vector3.Distance(this.transform.position, other.transform.position);
        thisRigidbody.AddForce((other.transform.position - this.transform.position).normalized * (G * (mass * other.Mass) / (r * r)));

        if(planetTransform != null)
            RotationAroundAxis();
    }
    public void SetUpVelocity(Celestial other, float G)
    {
        float r = Vector3.Distance(transform.position, other.transform.position);

        transform.LookAt(other.transform);
        this.transform.rotation *= Quaternion.Euler(0, 0, orbitalInclinationInDegrees);
        thisRigidbody.velocity += this.transform.right * Mathf.Sqrt((G * other.Mass) / r) * Convert.ToInt32(isMoving);
        this.transform.rotation = Quaternion.identity;
    }

    private void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
        thisRigidbody.mass = mass;
        thisRigidbody.useGravity = false;

        this.transform.localScale = Vector3.one * radius;
        this.transform.position = Vector3.forward * distanceFromTheSun;

        if (transform.childCount > 0)
        {
            planetTransform = transform.GetChild(0).GetComponent<Transform>();
            planetTransform.rotation *= Quaternion.Euler(0, 0, -rotaryAxisTilt);
        }
    }

    private void RotationAroundAxis()
    {
        planetTransform.rotation *= Quaternion.Euler(0, -rotationVelocity, 0);
    }
}
