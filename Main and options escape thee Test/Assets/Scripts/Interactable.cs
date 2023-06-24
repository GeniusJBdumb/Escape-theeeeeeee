using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abstract bcs. template for subclasses which have same properties as Interactable
public abstract class Interactable : MonoBehaviour 
{
    [SerializeField]
    public bool useEvents; // can with this add or remove Interaction event from gameobject

    [SerializeField]
    public string promptMessage;

    public virtual string OnLook()
    {
        return promptMessage; // message which is displayed when looking at interactive object
    }
    
    // player will call this function
    public void BaseInteract()
    {
        if (useEvents)
             GetComponent<InteractionEvent>().OnInteract.Invoke(); // event component for interaction (should never be null since use Editor script)


        // if (useEvents)
        //     GetComponent<InteractionEvent>().OnInteract.Invoke(); // event component for interaction (should never be null since use Editor script)
        // Interact();
    }

    // protected virtual void Interact()
    // {
    //     // template function which gets overwritten by subclasses like Buttons, or other objects
    // }

}
