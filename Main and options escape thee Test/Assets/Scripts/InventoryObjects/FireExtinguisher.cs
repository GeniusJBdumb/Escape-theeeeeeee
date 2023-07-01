using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class FireExtinguisher : Interactable, IInventoryItem // inherites from the IInventoryItem class
{
    [SerializeField]
    public string extinguishingAgent;
    public TextMeshProUGUI infoline;

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
    
    //called on Start
    void Start(){

        infoline = GameObject.Find("InfoLine").GetComponent<TextMeshProUGUI>(); //find the Infoline

    }

    // when the object is picked up
    public void OnPickup()
    {
        // pick and drop at certain places and when collision with objcet fire gets extinguished

        //Remove feedback text saying you can not apply the extinguisher on the fire.
        infoline.text = "";

        gameObject.SetActive(false); // object can basically not do anything now its gone
    }

    // when the object is droped again
    public void OnDrop()
    {
        RaycastHit hit = new RaycastHit();
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition); //  raycast to center of screen;    
        // Debug.DrawRay(ray.origin, ray.direction * distance); // to check ray -> use raycast function to check if hit something (will return bool)

        // if extinguisher gets dropped out, drop it at the position of the rycast
        if(Physics.Raycast(ray, out hit, 1000)) // with out we get the value for hit
        {
            // make object visible again and drop it at the place where the mous is currently
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
    }

    // Triggered when the collider of the Fire extinguisher hits another collider. Inherited from Monobehavior
    public void OnTriggerEnter(Collider other)
    {   
        //check whether the fire extinguisher is suitable for the fire (properties defined by us on the gameobject)
        if(extinguishingAgent == other.gameObject.GetComponent<Fire>().howToExtinguish)
        {
            other.gameObject.SetActive(false); //deactivate the fire
        }

        //In case there are mutliple Flames to be extinguished with the same FireExtinguisher Object,
        // we only want to remove the extinguisher from the Scene when all fires of the specific type are disabled/extinguished

        Fire[] flames = FindObjectsOfType<Fire>();
        
        if(! Array.Exists(flames, element => element.GetComponent<Fire>().howToExtinguish == extinguishingAgent)) //If there is not such a fire 
        {
            gameObject.SetActive(false); //deactivate fire extinguisher
        }
    }

    //As long as the fire extinguisher is in the fire display text
    public void OnTriggerStay(Collider other)
    {
        Debug.Log("Extinguisher is in fire");
        infoline.text = "Shit! This one does not fit!";
    }

    //When the  Fire Extinguisher leaves the fire remove the displayed text
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Extinguisher is not fire anymore");
        infoline.text = "";
    }
}
