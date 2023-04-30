using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Brightness : MonoBehaviour
{
    [SerializeField]
    private Slider brightnessSlider;
    [SerializeField]
    private PostProcessProfile brightness;
    [SerializeField]
    private PostProcessLayer layer;

    AutoExposure exposure;

    private void Start()
    {
        brightness.TryGetSettings(out exposure);
    }
    
    public void AdjustBrightness(float value)
    {
        if (value != 0)
        {
            exposure.keyValue.value = value;
        }
        else
        {
            exposure.keyValue.value = .05f;
        }
    }

}
