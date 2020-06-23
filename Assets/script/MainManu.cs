using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame()
    {
        SceneManager.LoadScene("playscene");
    }

    // Update is called once per frame
    public void quitGame()
    {
        Application.Quit();
    }
}
