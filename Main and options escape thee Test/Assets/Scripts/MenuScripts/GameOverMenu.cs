// script like the Main Menu script to switch between the scenes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for switching between scenes

public class GameOverMenu : MonoBehaviour
{
    // if main menu gets pressed
    public void GoToMainMenu()
    {

        // have Main as Scene 0 in build Index and Game in Index 1 --> current Index - 2 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

    }

    // if restart gets pressed
    public void Restart()
    {
        // go to play scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    // if Quit gets pressed end game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("PLayer Quit game");
    }
}
