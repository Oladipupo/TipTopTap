using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class unlocked : MonoBehaviour
{
    public static bool level1Unlock = false;
    public static bool level2Unlock = false;
    public static bool level3Unlock = false;

    void Start(){
        if(SceneManager.GetActiveScene().name == "level1" || SceneManager.GetActiveScene().name == "level1_easy"){
            unlocked.level1Unlock = true;
        }
        if(SceneManager.GetActiveScene().name == "level2" || SceneManager.GetActiveScene().name == "level2_easy"){
            unlocked.level2Unlock = true;
        }
        if(SceneManager.GetActiveScene().name == "level3" || SceneManager.GetActiveScene().name == "level3_easy"){
            unlocked.level3Unlock = true;
        }
    }
}
