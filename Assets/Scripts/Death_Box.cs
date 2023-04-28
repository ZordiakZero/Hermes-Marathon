using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death_Box : MonoBehaviour
{
    // The tag used for the player object
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the correct tag
        if (other.CompareTag(playerTag))
        {
            // Restart the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
