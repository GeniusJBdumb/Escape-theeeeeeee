using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireExtinguisher : Interactable, IInventoryItem // inherites from the IInventoryItem class
{
    [SerializeField]
    string extinguishingAgent;

    // give object a name and an image to put in inventory later
    public string Name
    {
        get
        {
            return gameObject.name;
        }
    }

    public Sprite _Image; // to assigne image in unityeditor

    // take the assigned image for item
    public Sprite Image 
    {
        get
        {
            return _Image;
        }

    }
    
    // when the object is picked up
    public void OnPickup()
    {
        // here add logic when pick up extinguisher if we need to but basically we only
        // pick and drop at certain places and when collision with objcet fire gets extinguished
        gameObject.SetActive(false); // object can basically not do anything now its gone
    }

    // when the object is droped again
    public void OnDrop()
    {
        // Need to move following logic to s bsse class or helper method to reuse it
        RaycastHit hit = new RaycastHit();
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition); //  raycast to center of screen;    
        // Debug.DrawRay(ray.origin, ray.direction * distance); // to check ray
        //  use raycast function to check if hit something (will return bool)
        if(Physics.Raycast(ray, out hit, 1000)) // with out getting value for hit
        {
            // make object visible again and drop it at the place where the mous is currently
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
    }

    // Triggered when the collider of the Fire extinguisher hits another collider
    public void OnTriggerEnter(Collider other)
    {   
        //check whether the fire extinguisher is suitable for the fire (properties defined by us on the gameobject)
        if(extinguishingAgent == other.gameObject.GetComponent<Fire>().howToExtinguish)
        {
        other.gameObject.SetActive(false); //deactivate the fire
        }

        //here we give the Player hints on why they can not use the extinugisher on the fire
        else if(extinguishingAgent != other.gameObject.GetComponent<Fire>().howToExtinguish && extinguishingAgent == "Powder")
        {
            StartCoroutine(displayInfo("I don't want to have Powder all over this place. I will never be all to clean all this mess. I should find another!"));
        }
        else if(extinguishingAgent != other.gameObject.GetComponent<Fire>().howToExtinguish && extinguishingAgent == "Foam")
        {
            StartCoroutine(displayInfo("I don't want to have Powder all over this place. I will never be all to clean all this mess. I should find another!"));
        }
        else if(extinguishingAgent != other.gameObject.GetComponent<Fire>().howToExtinguish && extinguishingAgent == "CO2")
        {
            StartCoroutine(displayInfo("I should not release any gas in this place. Gosh, I don't want to suffocate here!"));
        }

        
        //In case there are mutliple Flames to be extinguished with the same FireExtinguisher Object,
        // we only want to remove the extinguisher from the Scene when all fires of the specific type are disabled/extinguished

        Fire[] flames = FindObjectsOfType<Fire>();
        
        if(! Array.Exists(flames, element => element.GetComponent<Fire>().howToExtinguish == extinguishingAgent)) //If there is not such a fire 
        {
            gameObject.SetActive(false); //deactivate fire extinguisher
        }
    }
}
