using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mail : MonoBehaviour
{
    public int mailWorth = 2;
    public AudioSource soundSource;
    public AudioClip soundClip;

    void OnTriggerEnter(Collider other) 
    {
        other.gameObject.GetComponent<MailScore>().AddScore(mailWorth);
        this.gameObject.transform.GetChild(0).GetComponent<ParticleDestroy>().AboutToDie();
        soundSource.PlayOneShot(soundClip);
        //TODO: Access the UI and show a popup for getting the mail.
        Destroy(this.gameObject);
    } 
}
