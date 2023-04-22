using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Resolution : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutionDropdown;

    // Start is called before the first frame update

// If you uncomment this block and recompile, the dropdown WILL BREAK! AM WORKING ON A FIX STILL -Joel
    void Start()
    {
        AdjustResolution(resolutionDropdown.value);
    }

    public void AdjustResolution(float value)
    {
        if (resolutionDropdown.value == 0)
        {
            Console.log("Change resolution to 1420x960");
            Screen.SetResolution(1420, 960, false);

        }
        else if (resolutionDropdown.value == 1)
        {
            Console.log("Change resolution to 1024x800");
            Screen.SetResolution(1024, 800, false);
        }
        else if (resolutionDropdown.value == 2)
        {
            Console.log("Change resolution to 600x400");
            Screen.SetResolution(600, 400, false);
        }
    }
}
