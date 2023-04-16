using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Tracking : MonoBehaviour
{
    public Transform player;
    public float trackingSpeed = 0.125f; // The speed at which the camera will follow the player
    public Vector3 offset; // The distance between the camera and the player

    private void FixedUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Player is not selected to be tracked.");
            return;
        }

        // Calculate the player's position
        Vector3 playerPosition = player.position + offset;

        // Track between the current position and the player's new position
        Vector3 trackedPosition = Vector3.Lerp(transform.position, playerPosition, trackingSpeed);

        // Update the camera position
        transform.position = trackedPosition;
    }
}
