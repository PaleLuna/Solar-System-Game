using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownPlanet : MonoBehaviour
{
    [SerializeField] private Transform[] planet;

    public CameraTracking cameraTracking;

    public void InputMenu(int val)
    {
        if (cameraTracking)
            cameraTracking.SetNewTarget(planet[val]);
    }

}
