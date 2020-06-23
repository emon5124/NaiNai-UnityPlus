using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausetest : MonoBehaviour
{
    public float dsptimesong;
    // Start is called before the first frame update
    void Start()
    {
        dsptimesong = (float)AudioSettings.dspTime;
    }

    // Update is called once per frame
    void Update()
    {
        dsptimesong = (float)AudioSettings.dspTime;
    }
}
