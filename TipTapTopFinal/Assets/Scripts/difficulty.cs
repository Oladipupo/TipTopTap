using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficulty : MonoBehaviour
{
    public static bool Easy;
    
    public void switchDifficultyE(string text){
        Easy = true;
    }

    public void switchDifficultyN(string text){
        Easy = false;
    }
}
