using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    public void Highlight()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        // Perform the interaction logic here
        Debug.Log("Interacting with object: " + gameObject.name);
    }
}
