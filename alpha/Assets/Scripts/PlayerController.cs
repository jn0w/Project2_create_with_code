using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb; // Reference to the player's Rigidbody component
    public ParticleSystem jumpParticles; // Reference to the particle system for jumping effects

    private Vector3 initialPlayerPosition; // Store initial player position

    // Start is called before the first frame update
    void Start()
    {
        initialPlayerPosition = transform.position; // Store the initial player position when the game starts
    }

    // Private variables
    public float speed = 10; // Player's movement speed
    public float jumpForce = 10f; // Force applied when jumping
    private bool isGrounded; // Check if the player is on the ground

    private float horizontalInput; // Input for horizontal movement
    private float forwardInput; // Input for forward movement

    // Update is called once per frame
    void Update()
    {
        // Get player input for movement
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Apply movement force to the player
        rb.AddForce(new Vector3(horizontalInput, 0f, forwardInput) * speed);

        // Check for jump input and whether the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump(); // Execute jump function
        }
    }

    // Function to perform the jump action
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply jump force to the player's Rigidbody

        jumpParticles.Play(); // Start playing jump particles

        // Stop jump particles after 2 seconds
        Invoke("StopJumpParticles", 2.0f);
    }

    // Function to stop jump particles
    void StopJumpParticles()
    {
        jumpParticles.Stop(); // Stop playing jump particles
    }

    // Detect when the player collides with something
    public void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the ground
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true; // Set the player as grounded
        }
    }

    // Detect when the player stops colliding with something
    public void OnCollisionExit(Collision collision)
    {
        // Check if the collision is with the ground
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false; // Set the player as not grounded
        }
    }

    // Function to reset the player's position to the initial position
    public void ResetPlayerPosition()
    {
        transform.position = initialPlayerPosition; // Reset player position to its initial position
    }
}
