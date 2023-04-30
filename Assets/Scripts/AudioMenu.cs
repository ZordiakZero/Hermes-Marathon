using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer Mixer;
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private Slider mainVolumeSlider;
    [SerializeField]
    private Slider musicVoumeSlider;

    public void AdjustMainVolume(float value)
    {
        Mixer.SetFloat("Volume", Mathf.Log10(value) * 20);
    }
    public void AdjustMusicVolume(float value)
    {
        Mixer.SetFloat("Music", Mathf.Log10(value) * 20);
    }
}
