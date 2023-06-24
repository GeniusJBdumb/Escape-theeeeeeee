using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for switching between scenes

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // reference for menu that got created
    public static bool isPaused; // to see if game is paused already
    //public KeyCode pauseKey;
    //public bool hitCube;
    private InputManager inputManager;// reference to input manager

    void Start()
    {
        pauseMenu.SetActive(false); //initially the game is not paused
       // hitCube = false;
        inputManager = GetComponent<InputManager>(); // assign Inputmanager
        isPaused = false;

    }
    
    void Update()
    {
        // check if player presses pause button
        //if(//the cube is hit interaction stuff)
        //{
        //if (hitCube == true)
        if(inputManager.onFoot.Pause.triggered)
        {    
            Debug.Log("hit P Key");
            // fi the game is paused
            if(isPaused)
            {
                ResumeGame(); // start the gab´me again
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
        // we activate the pause menu panel
        pauseMenu.SetActive(true);
        // for pausing stop ingame clock -> zero
        Time.timeScale = 0f;
        isPaused = true;
     //   hitCube = true;
    }

    // if the game gets resumed
    public void ResumeGame()
    {
        // do opposite than in PauseGame
        // we deactivate the pause menu panel
        pauseMenu.SetActive(false);
        // for reuming start ingame clock again -> 1
        Time.timeScale = 1f;
        isPaused = false;
       // hitCube = false;

    }

    public void Options()
    {
        // we deactivate the pause menu panel
        pauseMenu.SetActive(false);

        // for pausing stop ingame clock -> zero
        Time.timeScale = 0f;
        isPaused = true;

       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    //public void HitCube()
    //{
     //   if(isPaused == false)
       // {
        //    hitCube = true;
       // }


   // }
    // if main Menu gets pressed start game
    public void GoToMainMenu()
    {
        // we deactivate the pause menu panel
        pauseMenu.SetActive(false);
        // for going back to start -> start ingame clock again -> 1
        Time.timeScale = 1f; 

        // have Main as Scene 0 in build Index and Game in Index 1 --> current Index - 1 
        // other option in loadScene("name of scene")
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
