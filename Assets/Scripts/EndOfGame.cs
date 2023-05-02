using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "Player")
        {
            Debug.Log("End of the game!");
        }
    }
}
