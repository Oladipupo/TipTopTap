using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlinkingText : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartBlinking();
    }

    IEnumerator Blink()
    {
        while(true)
        {
            text.text = "Get Ready For Some Fun!";
            yield return new WaitForSeconds(.5f);
            text.text = "Click HERE to Continue!";
            yield return new WaitForSeconds(.5f);
        }
    }

    void StartBlinking(){
        StartCoroutine("Blink");
    }
    void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}
