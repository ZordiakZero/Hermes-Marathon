using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mail : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        other.gameObject.GetComponent<MailScore>().AddScore();
        this.gameObject.transform.GetChild(0).GetComponent<ParticleDestroy>().AboutToDie();
        //TODO: Access the UI and show a popup for getting the mail.
        Destroy(this.gameObject);
    } 
}
