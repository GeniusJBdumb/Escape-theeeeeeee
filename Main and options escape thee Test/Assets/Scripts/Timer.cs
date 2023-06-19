using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
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
        // tell current time to in or decrease dependent of value of countdown
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        
        // if we have a limit and are going below or over the limit
        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            // update  taext and stop timer
            // SetTimerText();
            timerText.color = Color.red;
            enabled = false;
            gameOverEvent.Invoke(); // end the Game
            timerText.text = "GAME OVER";
        }
        else
        {
            SetTimerText(); // set a text

        }
    }

    private void SetTimerText()
    {
        // change text by making time to string and if have format-> use it; if ot -> just make numbers to string
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
    }
}

// for adjusting the way the timer is displayed as text
public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal,

}
