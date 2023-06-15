
// Script to channel all inputs through

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    
    private PlayerInput playerInput; // reference to c# player input script
    public PlayerInput.OnFootActions onFoot; // reference to movement

    private PlayerMotor motor; // property for player movement script
    private PlayerLook look; // property for player look script

    // Start is called before the first frame update
    void Awake()
    {
        // create new instance of class PlayerInput and get all info needed for movement
        playerInput = new PlayerInput(); 
        onFoot = playerInput.OnFoot; 

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        // for jump action
        // any time jump is performed use "call back context" and call jump function
        onFoot.Jump.performed += ctx => motor.Jump(); // create pointer to jump function
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // "playermotor move with values you get from movement action"
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>()); 
    }

    private void LateUpdate()
    {
        // "playermotor look around with values you get from rotation action"
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>()); 

    }
    
    
    // to use inputs in awake -> enable action map (same for disabeling)
    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
