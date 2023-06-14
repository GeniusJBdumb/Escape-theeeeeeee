
// Script to channel all inputs through

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    
    private PlayerInput playerInput; // reference to c# player input script
    private PlayerInput.OnFootActions onFoot; // reference to movement
    private PlayerMotor motor;// property for player movement script
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput(); // create new instance of class PlayerInput
        onFoot = playerInput.OnFoot; 
        motor = GetComponent<PlayerMotor>();

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
