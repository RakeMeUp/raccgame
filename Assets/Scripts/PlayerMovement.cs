using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 200f;
    [SerializeField] private float verticalSpeedMultiplier = 0.8f;
    [SerializeField] private float runSpeedRatio = 1.6f;
    private Interactable closestInteractable;
    private List<Interactable> interactables = new List<Interactable>();


    private Rigidbody2D rb;
    private Vector2 movement;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovementInput();
        HandleInteractionInput();
    }

    /// <summary>
    /// Handles the movement input
    /// </summary>
    private void HandleMovementInput()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical).normalized;
    }

    /// <summary>
    /// Handles the interaction input
    /// </summary>
    private void HandleInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && closestInteractable != null)
        {
            closestInteractable.Interact();
            Debug.Log("Interact key pressed");
        }
    }

    private void FixedUpdate()
    {
        CalculateClosestInteractable();
        UpdatePlayerVelocity();
    }

    /// <summary>
    /// Calculates the closest interactable object
    /// </summary>
    private void CalculateClosestInteractable()
    {
        float closestDistance = Mathf.Infinity;
        foreach (Interactable interactable in interactables)
        {
            float distance = Vector2.Distance(transform.position, interactable.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestInteractable = interactable;
            }
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)
        {
            interactables.Add(interactable);
            LogInteractables();
            Debug.Log("Enter proximity of object: " + other.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)
        {
            interactables.Remove(interactable);
            LogInteractables();
            Debug.Log("Exit proximity of object: " + other.gameObject.name);
        }

    }

    /// <summary>
    /// Logs the names of all interactables in proximity
    /// </summary>
    private void LogInteractables()
    {
        string log = "Interactables in proximity: ";
        foreach (Interactable interactable in interactables)
        {
            log += interactable.gameObject.name + ", ";
        }
        Debug.Log(log);
    }
}
