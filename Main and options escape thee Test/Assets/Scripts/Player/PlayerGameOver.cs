using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // for switching between scenes

public class PlayerGameOver : MonoBehaviour
{

    public TMP_Text leftTimeText; // text for checking condition that time has run out

    // Update is called once per frame
    void Update()
    {
        // if at some point in the game the text for Time Left is Game Over the player lost
        if (leftTimeText.text == "GAME OVER")
        {
            // go to game over scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
