using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    
    public AudioSource audio;
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
    void Update()
    {
        audio.volume = PlayerPrefs.GetFloat("MusicVolume");
        audio.volume = slider.value;
        PlayerPrefs.SetFloat("MusicVolume", audio.volume);

    }
}

