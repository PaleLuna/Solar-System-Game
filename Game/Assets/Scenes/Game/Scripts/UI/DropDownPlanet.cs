using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DropDownPlanet : MonoBehaviour
{
    [SerializeField] private SolarSystem solarSystem;
    [SerializeField] private CameraTracking cameraTracking;

    private TMP_Dropdown dropdown;

    public void InputMenu(int val)
    {
        if (cameraTracking)
            cameraTracking.SetNewTarget(solarSystem.GetCelestialTransform(val));
    }

    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        dropdown.options.Clear();

        for (int i = 0; i < solarSystem.GetSize(); i++)
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = solarSystem.at(i).name });
    }

}
