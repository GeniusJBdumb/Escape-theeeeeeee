using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireExtinguisher : MonoBehaviour, IInventoryItem // inherites from the IInventoryItem class
{
    // give object a name and an image to put in inventory later
    public string Name
    {
        get
        {
            return "FireExtinguisher";
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
    
    // pwhen the object is picked up
    public void OnPickup()
    {
        // here add logic when pick up extinguisher if we need to but basically we only
        // pick and drop at certain places and when collision with objcet fire gets extinguished
        gameObject.SetActive(false); // object can basically not do anything now its gone
    }

    // when the object is droped again
    public void OnDrop()
    {
        // NEeD to move following logic to s bsse class or heloer mehtod to reuse it
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

}
