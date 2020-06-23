using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManu : MonoBehaviour
{
    public bool backtoplay=false;
    // Start is called before the first frame update
    public void GoToMainManu()
    {
        SceneManager.LoadScene("Manu");
    }
    public void BackToPlay()
    {
        backtoplay = true;
    }
}