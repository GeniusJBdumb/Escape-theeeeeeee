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
        // other option in loadScene("name of scene")
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
        //add debug message
        Debug.Log("PLayer Quit game");
    }
}
