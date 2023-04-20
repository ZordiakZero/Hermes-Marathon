using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Resolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AdjustResolution(float value)
        {
            if (resolutionDropdown.value == 0)
            {
                Screen.SetResolution(1420, 960);

            }
            else if (resolutionDropdown.value == 1)
            {
                Screen.SetResolution(1024, 800);
            }
            else if (resolutionDropdown.value == 2)
            {
                Screen.SetResolution(600, 400);
            }
        }
    }
}
