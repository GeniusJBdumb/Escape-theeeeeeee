using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable // inherite from interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // overrides function in parent class Interactable. It is used for individual interactions for different types of Interactables
    public void Interact()
    {
        if(useEvents)
        {
            doorOpen = !doorOpen; // toggles between true or false
            door.GetComponent<Animator>().SetBool("IsOpen", doorOpen); // the animation
            Debug.Log("Interacted with " + gameObject.name);
        }

    }
}
