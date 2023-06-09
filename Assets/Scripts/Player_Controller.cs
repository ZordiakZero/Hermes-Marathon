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
    public GameplayMenu gameplayMenu;
    public AudioClip jumpSound;
   
    private Rigidbody rb;
    private bool isGrounded;
    private int remainingJumps;
    private char jumpInput;
    private AudioSource soundSource;
    private readonly IDictionary<char, KeyCode> jumpKeyCodes = new Dictionary<char, KeyCode>();

    SpriteRenderer sr;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        remainingJumps = extraJumps;
        jumpInput = gameplayMenu.JumpInput;
        InitializeJumpKeyCodes();
        soundSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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
        //Play movement sound
        if (moveHorizontal != 0f && isGrounded)
        {
            animator.SetBool("moving", true);
            if (!soundSource.isPlaying) {
                soundSource.Play();
            }
        }
        if (moveHorizontal == 0f ^ !isGrounded)
        {
            animator.SetBool("moving", false);
            soundSource.Stop();
        }

        if (moveHorizontal < 0 && !sr.flipX)
        {
            sr.flipX = true;
        } else if (moveHorizontal > 0 && sr.flipX)
        {
            sr.flipX = false;
        }
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Move the player character
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed);

        jumpInput = gameplayMenu.JumpInput;

        if (animator.GetBool("jumping") && isGrounded && moveVertical <= 0)
        {
            animator.SetBool("jumping", false);
        }

        // Jump when pressing W or Space, and the player has jumps remaining
        if ((Input.GetKeyDown(jumpKeyCodes[jumpInput]) || Input.GetKeyDown(KeyCode.Space)) && remainingJumps > 0)
        {
            animator.SetBool("jumping", true);
            this.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(jumpSound);
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            remainingJumps--;
        }

        
    }

    void InitializeJumpKeyCodes()
    {
        for (char c = 'A'; c <= 'Z'; c++)
        {
            KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), c.ToString(), true);
            jumpKeyCodes.Add(c, keyCode);
        }
    }
}
