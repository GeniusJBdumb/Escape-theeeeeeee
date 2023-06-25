using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable // inherite from interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;

    // Used for individual interactions for different types of Interactables
    public void Interact()
    {
        if(useEvents)
        {
            doorOpen = !doorOpen; // toggles between true or false
            door.GetComponent<AudioSource>().Play();
            door.GetComponent<Animator>().SetBool("IsOpen", doorOpen); // the animation
            Debug.Log("Interacted with " + gameObject.name);
        }
    }
}
