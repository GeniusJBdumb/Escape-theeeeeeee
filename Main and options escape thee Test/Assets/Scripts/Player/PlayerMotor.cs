// contains whole Player movement functionality
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded; // if  gravity
    public float speed = 5f;
    public float gravity = -9.81f; // how big is gravity (is downward force-> negative); this is earths one
    public float jumpHeight = 1f; // how heig we want to be able to jump
    
    // Start is called before the first frame update
    void Start()
    {
       controller = GetComponent<CharacterController>(); // get the character
    }

    // Update is called once per frame
    void Update()
    {
        // to ensure that do not have increase in gravity force -> constant update grounded bool
        isGrounded = controller.isGrounded;
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

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        // to apply constant gravity force to player for constant velocity on different devices
        playerVelocity.y += gravity  * Time.deltaTime;
        
        // to have every time same gravity force and no increasing one
        if (isGrounded && playerVelocity.y < 0) // if we are not jumping and gravity is negative less 0
            playerVelocity.y = -2f; // set velocity to some small negative value

        controller.Move(playerVelocity * Time.deltaTime);

        //Debug.Log(playerVelocity.y); // to see how much force is applied
    }

    // jump function for actual jumping

    public void Jump()
    {
        if (isGrounded) // check if we are already jumping -> no duble jumps allowed

            // set the velocity and allow to jump by considering the gravity  and the settled height
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    }
}
