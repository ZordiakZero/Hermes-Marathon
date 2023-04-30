using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour
{
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private Slider musicVoumeSlider;

    public void AdjustMusicVolume(float value)
    {
        AudioSource.volume = value;
        Debug.Log(value);
    }
}
