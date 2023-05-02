using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip CrusadersMarch;
    public AudioClip TownThemeII;
    public AudioClip TheDevilEpic;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayLevelMusic());
    }

    IEnumerator PlayLevelMusic()
    {
        string currentLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        char levelNum = currentLevel[currentLevel.Length - 1];

        switch (levelNum)
        {
            case '1':
                audioSource.clip = CrusadersMarch;
                break;
            case '2':
                audioSource.clip = TownThemeII;
                break;
            case '3':
                audioSource.clip = TheDevilEpic;
                break;
            default:
                Debug.LogError("Invalid level index.");
                yield break;
        }

        audioSource.Play();

        while (audioSource.isPlaying)
        {
            yield return null;
        }
    }
}