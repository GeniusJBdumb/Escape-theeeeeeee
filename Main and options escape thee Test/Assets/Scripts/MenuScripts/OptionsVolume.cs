using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsVolume : MonoBehaviour
{
    // function to adjust volume with slider in options and pause menu

    // public variable to access mixer number
    public AudioMixer audioMixer;

    // function which sets float from audioMixer to float set with slider in game
    public void SetVolume (float volume)
    {
        // set the MainVolume of the master mixer to the given volume with game slider
        audioMixer.SetFloat("MainVolume", volume); 

        // a debug info about volume change
        Debug.Log(volume);
    }
}
