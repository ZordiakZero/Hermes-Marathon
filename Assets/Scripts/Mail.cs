using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mail : MonoBehaviour
{
    public int mailWorth = 2;
    private AudioSource soundSource;
    public AudioClip soundClip;

    void OnTriggerEnter(Collider other) 
    {
        soundSource = other.gameObject.transform.GetChild(1).GetComponent<AudioSource>();
        soundSource.PlayOneShot(soundClip);
        other.gameObject.GetComponent<MailScore>().AddScore(mailWorth);
        this.gameObject.transform.GetChild(0).GetComponent<ParticleDestroy>().AboutToDie();
        Destroy(this.gameObject);
    } 

}
