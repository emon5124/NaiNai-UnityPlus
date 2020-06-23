using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStartVolume : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
