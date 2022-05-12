using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    [Tooltip("Гравитационная постоянная")]
    [SerializeField] private float G;

    [SerializeField] private Celestial[] celestials;

    private void Start()
    {
        GameObject[] gObj = GameObject.FindGameObjectsWithTag("SpaceObject");
        celestials = new Celestial[gObj.Length];
        int i = 0;
        foreach (GameObject obj in gObj)
        {
            Celestial cel = obj.GetComponent<Celestial>();
            if (cel != null)
                celestials[i++] = cel;
        }

        InitialVelocity();
    }

    private void FixedUpdate()
    {
        Gravity();
    }
    private void Gravity()
    {
        foreach(Celestial firstObj in celestials)
            foreach(Celestial secondObj in celestials)
                if(!firstObj.Equals(secondObj))
                    firstObj.MoveWithGravity(secondObj, G);
    }

    private void InitialVelocity()
    {
        foreach (Celestial firstObj in celestials)
            foreach (Celestial secondObj in celestials)
                if (!firstObj.Equals(secondObj))
                    firstObj.SetUpVelocity(secondObj, G);
    }


}
