using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    public void OnPickup()
    {
        // here add logic when pick up extinguisher if we need to but basically we only
        // pick and drop at certain places and when collision with objcet fire gets extinguished
        gameObject.SetActive(false); // object can basically not do anything now its gone
        Debug.Log("SetActive Extinguisher to false");
    }

}
