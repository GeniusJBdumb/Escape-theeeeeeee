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

    // ovverrides function in parent class for individual interaction
    protected override void Interact()
    {
        doorOpen = !doorOpen; // toggles between true or false
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen); // the animation
        Debug.Log("Interacted with " + gameObject.name);
    }
}
