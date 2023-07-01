using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// template for subclasses which have same properties as Interactable -> abstract
public abstract class Interactable : MonoBehaviour 
{
    [SerializeField]
    public bool useEvents; // can with this add or remove Interaction event from gameobject

    [SerializeField]
    public string promptMessage; // can make a message if an interaction happens

    public virtual string OnLook()
    {
        return promptMessage; // message which is displayed when looking at interactive object
    }
    
    // player will call this function
    public void BaseInteract()
    {
        GetComponent<InteractionEvent>().OnInteract.Invoke(); // event component for interaction (should never be null since we use the Editor script))
    }
    
    // This function is called within the child classes using StartCoroutine(displayInfo(text))
    // It is used to display Infotext above the Inventory for a certain amount of time
    public IEnumerator displayInfo(string text, int time = 5)
    {
        TextMeshProUGUI infoline = GameObject.Find("InfoLine").GetComponent<TextMeshProUGUI>();
        infoline.text = text;
        yield return new WaitForSeconds(time);
        infoline.text = "";
    }

}
