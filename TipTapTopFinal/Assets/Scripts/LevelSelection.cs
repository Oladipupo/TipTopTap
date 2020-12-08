using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;

    

    void Start()
    {
        if(unlocked.level1Unlock){
            lvlButtons[0].interactable = true;
        }
        else{
            lvlButtons[0].interactable = false;
        }
        if(unlocked.level2Unlock){
            lvlButtons[1].interactable = true;
        }
        else{
            lvlButtons[1].interactable = false;
        }
        if(unlocked.level3Unlock){
            lvlButtons[2].interactable = true;
        }
        else{
            lvlButtons[2].interactable = false;

        }
    }
}
