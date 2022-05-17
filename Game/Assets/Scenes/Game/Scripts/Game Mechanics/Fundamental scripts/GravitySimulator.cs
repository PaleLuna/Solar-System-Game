using UnityEngine;

[RequireComponent(typeof(SolarSystem))]
public class GravitySimulator : MonoBehaviour
{
    [Tooltip("Гравитационная постоянная")]
    [SerializeField] private float G;

    private SolarSystem celestials;

    private void Start()
    {
        celestials = GetComponent<SolarSystem>();
        InitialVelocity();
    }

    private void FixedUpdate()
    {
        Gravity();
    }
    private void InitialVelocity()
    {
        for (int i = 0; i < celestials.GetSize(); i++)
            for (int j = 0; j < celestials.GetSize(); j++)
                if (!celestials.at(i).Equals(celestials.at(j)))
                    celestials.at(i).SetUpVelocity(celestials.at(j), G);
    }
    private void Gravity()
    {
        for (int i = 0; i < celestials.GetSize(); i++)
            for (int j = 0; j < celestials.GetSize(); j++)
                if (!celestials.at(i).Equals(celestials.at(j)))
                    celestials.at(i).MoveWithGravity(celestials.at(j), G);
    } 
}
