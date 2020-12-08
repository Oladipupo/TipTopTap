using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            SceneManager.LoadScene("Credits");
        }
        if (Input.GetKeyDown("x"))
        {
            SceneManager.LoadScene("Setting");
        }
        if (Input.GetKeyDown("c"))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown("v"))
        {
            SceneManager.LoadScene("TutorialLevel");
        }
    }

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad() {
        PlayerPrefs.DeleteAll();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("CutScene1");
    }

    public void ResetGame()
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

    public void TutorialLevel(){
        SceneManager.LoadScene("TutorialLevel");
    }

    public void LevelPicker(){
        SceneManager.LoadScene("LevelPicker");
    }

    public void Level1(){
        if(difficulty.Easy != true){
            SceneManager.LoadScene("level1");
        }
        else{
            SceneManager.LoadScene("level1_easy");
        }
    }

    public void Level2(){
        if(difficulty.Easy != true){
            SceneManager.LoadScene("level2");
        }
        else{
            SceneManager.LoadScene("level2_easy");
        }
    }

    public void Level3(){
        if(difficulty.Easy != true){
            SceneManager.LoadScene("level3");
        }
        else{
            SceneManager.LoadScene("level3_easy");
        }
    }

}
