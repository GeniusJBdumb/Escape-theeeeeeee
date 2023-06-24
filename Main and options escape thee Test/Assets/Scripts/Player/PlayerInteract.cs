// contains all logic to detect interactables and handles player input for objects
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    
    private Camera cam; // reference to camera 

    [SerializeField] // to make distance visible in inspector
    private float distance = 3f; // for defining shooting distance of the shooter in ray i.e. detects collides up to dis 3 
    
    [SerializeField] // to make mask visible in inspector
    private LayerMask mask; // represents if objects can be hit (1) and not be hit (0) by player
    private PlayerUI  playerUI; // private property for PlayerUI script
    private InputManager inputManager;// reference to input manager

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam; // can get cam like this bcs. already attached to player
        playerUI = GetComponent<PlayerUI>(); // get UI via playerUI script
        inputManager = GetComponent<InputManager>(); // assign Inputmanager

    }

    // going to do ray cast
    // 1. Ray var containing orignin (camera/player) and direction (forward) to detect colliders 
    // raycasthit var as store for info about collition (distance, ridgidbody ...)
    // raycast() func checks for collisions
    void Update()
    {
        
        // clear message when not looking at interactable i.e. empty string
        playerUI.UpdateText(string.Empty);
        // ray at center of cam with forward direction
        Ray ray =  new Ray(cam.transform.position, cam.transform.forward);
        // Debug.DrawRay(ray.origin, ray.direction * distance); // to check ray

        // variable to store collision info
        RaycastHit hitInfo;

        // raycast to center of screen; use raycast function to check if hit something (will return bool)
        if(Physics.Raycast(ray, out hitInfo, distance, mask)) // with out getting value for hitInfo
        {
            // check if we actually had a collision with interactable component
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                // if had collision

                // creating temp variable storing interactable (temp since use several times)
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                
                // update the text displayed when collition with certain object happened
                playerUI.UpdateText(interactable.promptMessage);
                
                // each time when player changes state of interact action -> triggered becomes true
                
                if(inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract(); // in BaseInteract calling Interact function -> will run interact function in script for object e.g. Keypad
                }
            }
        }
    }
    
}
