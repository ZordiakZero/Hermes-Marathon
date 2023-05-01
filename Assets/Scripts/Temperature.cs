using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Temperature : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Dropdown temperatureDropdown;
    [SerializeField]
    private PostProcessProfile temperature;
    [SerializeField]
    private PostProcessLayer layer;

    ColorGrading colorGrading;

    // Start is called before the first frame update
    void Start()
    {
        temperature.TryGetSettings(out colorGrading);
    }

    public void AdjustTemperature(int value)
    {
        if (temperatureDropdown.value == 0)
        {
            colorGrading.temperature.value = 0;

        }
        else if (temperatureDropdown.value == 1)
        {
            colorGrading.temperature.value = -100;
        }
        else if (temperatureDropdown.value == 2)
        {
            colorGrading.temperature.value = 100;
        }
    }
}
