using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Interactable : MonoBehaviour, IInteractable
{
    public DialogueRunner dialogueRunner;
    public void Highlight()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        // Perform the interaction logic here
        Debug.Log("Interacting with object: " + gameObject.name);
        dialogueRunner.StartDialogue("Frog");
    }
}
