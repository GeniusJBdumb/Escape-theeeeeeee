using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class Fire : Interactable // inherite from Interactable
{

    [SerializeField]
    GameObject blockedObject;

    [SerializeField]
    public string howToExtinguish;


    void Update() 
    {

        // We want to use the fire to block the interaction with the Keypad.
        // We implement this by disabeling the useEvent bool from the Interactable as long as it is active.
        if (blockedObject != null){
            try
            {
                blockedObject.GetComponent<Interactable>().useEvents = false;
                
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e);
                throw;
            }
        }
    }

    public void OnDisable()
    {
        blockedObject.GetComponent<Interactable>().useEvents = true;
    }

}
