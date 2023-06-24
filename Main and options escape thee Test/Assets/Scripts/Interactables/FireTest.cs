using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class FireTest : Interactable // inherite from Interactable
{

    [SerializeField]
    private GameObject blockedObject; //Get an Object which interaction we want to toggle 
    private string blockedScript = ""; // this the name of the script of the blockedObject (retrived in Start())

    // Start is called before the first frame update
    void Start() 
    {

        //Find a Interactable Script within the Components from the blockedObject.based on our organizaiton, we assume that it is in ./Scripts/Interactables 
        // We need this because we want to use the fire to block the interaction with other Interactables (e.g. the Keypad). 
        // We implement this by disabeling the useEvent bool from the Interactable. But we need to get the fitting Component from the blockedObject.

        if(blockedObject){
            //1. Collect the filenames of all Interactables
            string path = Path.GetFullPath(".");
            path += "\\Assets\\Scripts\\Interactables";  //setting the path of the ./Interactables Folder

            string[] Files = Directory.GetFiles(path, "*.cs"); //Getting all Files in ./Interactables
            List<string> filenames  = new List<string>(); //create a list which contains all Interactables

            foreach(string file in Files) {
            filenames.Add(Path.GetFileNameWithoutExtension(file));}

            //2. Use this Array of Filenames to compare these with the Components
            Component[] components = blockedObject.GetComponents(typeof(Component)); //list of all Components of blockedObject
            string[] filenames_array = filenames.ToArray(); //converting filenames to Array to use Array.Exists in the next step

            foreach(Component component in components){
                Debug.Log(component);

                //extract the component name
                string name = component.ToString();             //string with form "GameObject (ComponentType)", we want the ComponentType, which is the Script Name
                name = name.Substring(name.IndexOf('(') + 1).TrimEnd(')');

                //check whether the Component is an Interactable (Whether the blockedObject has a Script from ./Interactables )
                if( Array.Exists(filenames_array, element => element == name)){ 
                    blockedScript = name;
                }
            }


            //3. At the games start the fire should block the blockedObject. Therefore, we set the useEvents bool to false.
            //Including exception handling if blocked_obeject does not have a Script from ./Interactables
            try
            {
                // Component comp = blockedObject.GetComponent<String.Format("{0}", blockedScript)>();
                // comp.useEvents = false;
                //blockedObject.blockedScript.useEvents = false;
                //blockedObject.GetComponent(Keypad).useEvents = false;
                //blockedObject.GetComponent(Type.GetType(Interactable)).useEvents = false;


                // Debug.Log(comp.ToString());
                // comp.SetBool("useEvents", false);
                
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e);
                throw;
            }
            
        }
        
        
    }

        //set the useEvents Bool on false, if it is blocked by fire(coupled fire exists)
        //blockedObject.GetComponent<XXXXXXXX> = false;

    // public void Interact()
    // {

    //     blockedObject.GetComponent(blockedScript).UseEvents = true;
    //     blockedObject.SetActive(false);
    //     Debug.Log("Interacted with ", gameObject.name);
    // }

}
