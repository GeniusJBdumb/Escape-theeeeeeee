// contains whole Player movement functionality
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
       controller = GetComponent<CharacterController>(); // get the character
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // receives inputs for input manager script (InputManager.cs) and applies them to character controller
    public void ProcessMove(Vector2 input) // coordinate input vector for position
    {
        Vector3 moveDirection = Vector3.zero;

        // set position values in move vector to given input coordinates
        moveDirection.x = input.x;
        moveDirection.z = input.y; // apply y component to z axis ->         translates vertical movement in forward backward movement


        // move with given speed but add Time.deltaTime to get scaled movement for each engine where game is running on
        // expl. each computer has different framerate etc. makes game run same on each

        // ADD DEBUG LOG HERE BUT DO NOT KNOW WHICH ONE 
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
    }
}
