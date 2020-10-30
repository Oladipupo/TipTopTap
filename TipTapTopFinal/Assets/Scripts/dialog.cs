using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class dialog : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public AudioClip[] sentencesAudio;
    public AudioSource audioSource;
    private int index;
    public float typingSpeed;
    private bool allowClick = false;
    public string nextLevelName;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
        if(difficulty.Easy == true && nextLevelName != "CutScene5")
            nextLevelName = nextLevelName + "_easy";
    }

    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            allowClick = true;
        }
        if (allowClick ==true && Input.anyKeyDown)
        {
            nextSentence();
        }
    }


    IEnumerator Type()
    {
        audioSource.clip = sentencesAudio[index];
        audioSource.Play();

        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void nextSentence()
    {
        allowClick = false;
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            Application.LoadLevel(nextLevelName);
        }
    }

    public void skipIt()
    {
        Application.LoadLevel(nextLevelName);
    }
}
