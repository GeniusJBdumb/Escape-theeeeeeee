using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for switching between scenes
using TMPro;

public class WinMenu : MonoBehaviour
{

    public UpdateWinTime updater;
    public TMP_Text targetTextMesh;

    // if main menu gets pressed
    public void GoToMainMenu()
    {

        // have Main as Scene 0 in build Index and Win in Index 1 --> current Index - 3 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);

    }

    // if again playing gets pressed
    public void Again()
    {
        // go to play scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    // if Quit gets pressed end game
    public void Quit()
    {
        Application.Quit();
        
        Debug.Log("PLayer Quit game");
    }
    
    // If the Win scene is build for the first time
    void Start()
    {
        targetTextMesh = WinTrigger.textToPass; // get the needed time text of the player of the game scene by getting the value of texToPass from the WinTrigger SCript
        Debug.Log("I got the TEEEEXXXXT" + targetTextMesh.text);

        updater.UpdateText(targetTextMesh.text); // update the text at the object (the "time needed" button which contains the text (see win menu canvas script assignment))
    }

}
