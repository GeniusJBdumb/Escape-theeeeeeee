using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script which implements the function of looking around and rotating the camera according to player mouse movement
public class PlayerLook : MonoBehaviour
{
    public Camera cam; // property for camera
    private float xRotation = 0f; // rotation movement on x axis

    // for how intense rotation will be given certain playerinput
    public float xSensitivity = 70f; 
    public float ySensitivity = 70f;

    public void ProcessLook(Vector2 input) // like processMove function to coordinate input vector for rotation
    {
        // create local floats for input values
       float mouseX = input.x;
       float mouseY = input.y;  
    
        // calculate camera rotation for look up and dowm
        xRotation -=  (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);// clampt/restrict xRotation to value in given range
        
        // apply rotation to camera by changing x axis value
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // for looking to left and right -> rotate player (with object since cam on player)
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
