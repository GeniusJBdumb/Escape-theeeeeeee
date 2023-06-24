using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class OptionsVolume : MonoBehaviour
{
    // function to adjust volume with slider in options and pause menu
    [SerializeField] 
    public Slider slider; 

    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolumne"))
        {
            PlayerPrefs.SetFloat("musicVolumne", 1);
            Load();
        }

    }

    // function which sets float from audioMixer to float set with slider in game
    public void SetVolume()
    {
        // set the MainVolume of the master mixer to the given volume with game slider
        AudioListener.volume = slider.value;
        Save();
    }

    public void Load()
    {
        slider.value = PlayerPrefs.GetFloat("musicVolumne");

    }
    
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolumne", slider.value);
    }
}