using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("level1");
    }

    public void BackGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits(){
        SceneManager.LoadScene("Credits");
    }

    public void Settings(){
        SceneManager.LoadScene("Setting");
    }
}
