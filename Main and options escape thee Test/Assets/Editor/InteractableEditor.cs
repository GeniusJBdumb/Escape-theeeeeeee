using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Interactable),true)] // script does also affect child classes of Interacable

public class InteractableEditor : Editor // to inherit from Editor
{
    public override void OnInspectorGUI() // gets called everytime unity updates editor interface 
    {
        Interactable interactable = (Interactable)target; // strore instance of interactable script target: current gameobject which is inspected -> cast object to interactable
        
        // if we haven an Eventonly interactable
        if(target.GetType() == typeof(EventOnlyInteractable))
        {
            // here the component will be completely blank --> manually build prompt message field
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", interactable.promptMessage); // event only interactable
            EditorGUILayout.HelpBox("EventOnlyInteract. can ONLY use UnityEvents.", MessageType.Info); // this gets displayed as helper info in the unity engine 
            
            // --> if there is no interaction event, then add one
            if(interactable.GetComponent<InteractionEvent>() == null)
            {
                interactable.useEvents = true;
                interactable.gameObject.AddComponent<InteractionEvent>(); // add on an interaction component
            }
        }
        else
        {

            base.OnInspectorGUI(); // interactable component how it appears without no modification
            // check if interactable uses events and if it does...
            if (interactable.useEvents)
            {
                // and if there is no event yet
                if(interactable.GetComponent<InteractionEvent>() == null)
                    interactable.gameObject.AddComponent<InteractionEvent>(); // add on an interaction component
            }
            else
            {
                // events are not in usage and the compoent is removed
                if(interactable.GetComponent<InteractionEvent>() != null)
                    DestroyImmediate(interactable.GetComponent<InteractionEvent>());
            }
        }    
    }
}