using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DropDownPlanet : MonoBehaviour
{
    [SerializeField] private SolarSystem solarSystem;

    private TMP_Dropdown dropdown;

    public delegate void ChangePlanet(Transform newTarget);
    public static event ChangePlanet changePlanet;

    public void InputMenu(int val)
    {
        changePlanet?.Invoke(solarSystem.GetCelestialTransform(val));
    }

    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        dropdown.options.Clear();

        for (int i = 0; i < solarSystem.GetSize(); i++)
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = solarSystem.at(i).name });
    }

}
