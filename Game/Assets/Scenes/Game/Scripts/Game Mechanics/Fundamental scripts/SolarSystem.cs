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
    public Transform GetCelestialTransform(int ind)
    {
        return celestials[ind].transform;
    }

    private void Awake()
    {
        celestials = new Celestial[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            celestials[i] = transform.GetChild(i).GetComponent<Celestial>();
    }
}
