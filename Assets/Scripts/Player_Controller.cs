using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
     public float moveSpeed = 5f;
    public float jumpSpeed = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public int extraJumps = 1;

    private Rigidbody rb;
    private bool isGrounded;
    private int remainingJumps;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        remainingJumps = extraJumps;
    }

    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            remainingJumps = extraJumps;
        }

        // Get player input for horizontal movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Move the player character
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed);

        // Jump when pressing W or Space, and the player has jumps remaining
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && remainingJumps > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            remainingJumps--;
        }
    }
}
