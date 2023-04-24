using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    [Range (3.0f, 6.0f)]
    public float timeToDie = 3.0f;

    public void AboutToDie() {
        this.transform.parent = null;
        this.gameObject.GetComponent<ParticleSystem>().Play();
        StartCoroutine(DestroyAfter());
    }

    IEnumerator DestroyAfter() {
        yield return new WaitForSeconds(timeToDie);
        Destroy(this.gameObject);
    }
}
