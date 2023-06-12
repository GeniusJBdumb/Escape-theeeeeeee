using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for switching between scenes

public class MainMenu : MonoBehaviour
{
    // if play gets pressed start game
    public void Play()
    {
        // have Main as Scene 0 in build Index and Game in Index 1 --> current Index + 1 
        // other option in loadScene("name of scene")
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    // if Quit gets pressed end game
    public void Quit()
    {
        Application.Quit();
        //add debug message
        Debug.Log("PLayer Quit game");
    }
}
