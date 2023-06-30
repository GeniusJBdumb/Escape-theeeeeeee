using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for switching between scenes

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // reference for menu that got created
    public static bool isPaused; // to see if game is paused already

    private InputManager inputManager;// reference to input manager

    void Start()
    {
        pauseMenu.SetActive(false); //initially the game is not paused
        inputManager = GetComponent<InputManager>(); // assign Inputmanager
        isPaused = false;
    }
    
    void Update()
    {
        // check if player presses pause key
        if(inputManager.onFoot.Pause.triggered)
        {    
            Debug.Log("hit P Key");

            if(isPaused)
            {
                ResumeGame(); // start the game again
            }
            else
            {
                PauseGame(); //stop the game
            }
        }
    }

    // if the game gets paused
    public void PauseGame()
    {
        // activate the pause menu panel
        pauseMenu.SetActive(true);
        // for pausing stop ingame clock -> zero
        Time.timeScale = 0f;
        isPaused = true;
    }

    // if the game gets resumed
    public void ResumeGame()
    {
        // do opposite than in PauseGame
        // deactivate the pause menu panel
        pauseMenu.SetActive(false);
        // for resuming start ingame clock again -> 1
        Time.timeScale = 1f;
        isPaused = false;
    }

    // if main Menu gets pressed start game
    public void GoToMainMenu()
    {
        // deactivate the pause menu panel
        pauseMenu.SetActive(false);
        // for going back to start -> start ingame clock again -> 1
        Time.timeScale = 1f; 

        // have Main as Scene 0 in build Index and Game in Index 1 --> current Index - 1 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    // if Quit gets pressed end game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("PLayer Quit game");
    }
}
