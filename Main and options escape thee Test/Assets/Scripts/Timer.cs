using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

// the timer class found on the timerobjects
public class Timer : MonoBehaviour
{
    // the variables which can be adjusted for the timer in the Unity editor
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;

    // dictionary for the format key and the given string output for the format
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();

    // the Event for the limited timer for the lose of the game
    public UnityEvent gameOverEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        // add the formats to the format dictionary to use them later
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        // If countdown = True, decrease the time shown in timer
        // If countdown = False, increase the time shown in timer
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        
        // if we have a limit and are going below/over the limit
        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            // update text and stop timer and end the game
            timerText.color = Color.red;
            enabled = false;
            gameOverEvent.Invoke();
            timerText.text = "GAME OVER";
            Debug.Log("Game over Limit reached -> End Game");
            // Note: one could generalize this part to create other events after a limit than just game over but this here suffices our needs
        }
        else
        {
            SetTimerText(); // set text with the approriate time
        }
    }

    // sets the time text for the given timer objects
    private void SetTimerText()
    {
        // change text by making time to string and if have format-> use it; if not -> just make numbers to string
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
    }
}

// for adjusting the way the timer is displayed as text (the keys of the dictionary)
public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal,

}
