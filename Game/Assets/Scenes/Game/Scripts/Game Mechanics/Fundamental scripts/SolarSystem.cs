using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    [SerializeField] private Celestial[] celestials;
    
    public int GetSize()
    {
        return celestials.Length;
    }
    public Celestial at(int ind)
    {
        return celestials[ind];
    }
    public Vector3 GetCelestialPos(int ind)
    {
        return celestials[ind].transform.position;
    }

    private void Start()
    {
        celestials = GameObject.FindObjectsOfType(typeof(Celestial)) as Celestial[];
    }
}
