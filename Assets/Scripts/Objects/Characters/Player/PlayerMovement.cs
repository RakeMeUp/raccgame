using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 200f;
    [SerializeField] private float verticalSpeedMultiplier = 0.5f;
    [SerializeField] private float runSpeedRatio = 1.6f;
    

    private Rigidbody2D rb;
    private Vector2 movement;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovementInput();
    }

    private void FixedUpdate()
    {
        UpdatePlayerVelocity();
    }

    private void HandleMovementInput()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical).normalized;
    }

    /// <summary>
    /// Updates the player's velocity based on the movement vector
    /// </summary>
    private void UpdatePlayerVelocity()
    {
        float currentMoveSpeed = Input.GetKey(KeyCode.LeftShift) ? moveSpeed * runSpeedRatio : moveSpeed;
        Vector2 velocity = currentMoveSpeed * Time.fixedDeltaTime * movement.normalized;
        if (movement.y != 0)
        {
            velocity.y *= verticalSpeedMultiplier;
        }

        rb.velocity = velocity;
    }
}
