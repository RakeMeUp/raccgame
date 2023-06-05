using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed; // Adjust the movement speed as needed
    public float verticalSpeedMultiplier;// Adjust the vertical speed multiplier as needed


    private Rigidbody2D rb;
    private Vector2 movement;
    public float deceleration = 0.5f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get input from arrow keys
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Calculate movement vector
        movement = new Vector2(moveHorizontal, moveVertical).normalized;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = moveSpeed * Time.fixedDeltaTime * movement.normalized;
        if (movement.y != 0)
        {
            velocity.y *= verticalSpeedMultiplier;
        }

        rb.velocity = velocity;

        // Apply deceleration when no input is detected
        if (velocity.magnitude < 0.01f)
        {
            rb.velocity *= deceleration;
        }
    }
}
