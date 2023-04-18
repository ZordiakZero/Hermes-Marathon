using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayMenu : MonoBehaviour
{
    public Renderer renderer;
    public Material protanopiaMaterial;
    public Material deuteranopiaMaterial;
    public Material tritanopiaMaterial;
    public TMPro.TMP_Dropdown myDrop;

    public void ColorSelector()
    {
        if (myDrop.value == 0)
        {
            renderer.material = protanopiaMaterial;
        }
        else if (myDrop.value == 1)
        {
            renderer.material = protanopiaMaterial;
        }
        else if (myDrop.value == 2)
        {
            renderer.material = deuteranopiaMaterial;
        }
        else if (myDrop.value == 3)
        {
            renderer.material = tritanopiaMaterial;
        }
    }

}
