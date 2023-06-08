using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private Interactable closestInteractable;
    private readonly List<Interactable> interactables = new();
    public Collider2D interactableCollider;

    // Update is called once per frame
    void Update()
    {
        HandleInteractionInput();
    }
    private void FixedUpdate()
    {
        CalculateClosestInteractable();
    }

    private void HandleInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && closestInteractable != null)
        {
            closestInteractable.Interact();
            Debug.Log("Interact key pressed");
        }
    }

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
