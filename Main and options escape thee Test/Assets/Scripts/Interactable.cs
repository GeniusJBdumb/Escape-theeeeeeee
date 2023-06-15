using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abstract bcs. template for subclasses which have same properties as Interactable
public abstract class Interactable : MonoBehaviour 
{
    public string promptMessage; // message which is displayed when looking at interactive object

    // player will call this function
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        // template function which gets overwritten by subclasses like Buttons, or other objects
    }

}
