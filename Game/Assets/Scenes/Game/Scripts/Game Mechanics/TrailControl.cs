using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class TrailControl : MonoBehaviour
{
    private TrailRenderer trailRenderer;

    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.enabled = false;
        this.enabled = false;
    }

    private void OnEnable()
    {
        trailRenderer.enabled = true;
    }
    private void OnDisable()
    {
        trailRenderer.enabled = false;
    }
}
