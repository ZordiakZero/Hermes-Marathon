using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    public float timeToDie = 3.0f;

    public void AboutToDie() {
        this.gameObject.transform.parent = null;
        this.gameObject.GetComponent<ParticleSystem>().Play();
        StartCoroutine(DestroyAfter(timeToDie));
    }

    IEnumerator DestroyAfter(float timeToDestroy) {
        if (timeToDestroy > 0f & timeToDestroy < 10f)
        {
            yield return new WaitForSeconds(timeToDestroy);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("timeToDestroy not valid: " + timeToDestroy);
        }
    }
}
