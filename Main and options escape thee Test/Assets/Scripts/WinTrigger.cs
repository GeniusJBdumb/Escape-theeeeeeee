using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for switching between scenes
using TMPro;

// is the trigger for the floors after the doo. if player triggers them then switch to win scene
public class WinTrigger : MonoBehaviour
{   
    public static TMP_Text textToPass;

    // if player collides with the floor the game is won -> go to win scene
    void OnTriggerEnter(Collider other)
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        textToPass = GameObject.FindWithTag("Time").GetComponent<TMP_Text>();
        Debug.Log("found text and passed it");
    }

}
