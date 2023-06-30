// script of mainmenu canvas to implement the scene switching functions -> depending on which button gets pressed the functions get executed
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    // if Quit gets pressed end game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("PLayer Quit game");
    }
}
