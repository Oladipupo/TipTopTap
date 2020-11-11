using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class manageSounds : MonoBehaviour
{
    public int totalNotesInSequence;
    public int[] correct_sequence= new int [5];
    public int[] input_sequence = new int [5];
    public int chances = 2;
    private int count = 0;
    private bool wrong = false;
    private bool recording = false;
    public AudioClip[] notesSounds;
    public AudioSource audioSource;
    public AudioClip melody;
    public Text onText;
    public Text offText;
    public Button melodyButton;
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        offText.enabled = true;
        onText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void inputNote(int note)
    {
        if (recording)
        {
            input_sequence[count] = note;
            count++;
            audioSource.clip = notesSounds[note];
            audioSource.Play();
            if (count == totalNotesInSequence)
            {
                checkSequence();
            }
        }
        else
        {
            audioSource.clip = notesSounds[note];
            audioSource.Play();
        }

    }
    void checkSequence()
    {
        for(int i =0; i< totalNotesInSequence; i++)
        {
            if (input_sequence[i] != correct_sequence[i])
            {
                wrong = true;
            }
        }
        if (wrong)
        {
            count = 0;
            Debug.Log("WRONG");
        }
        else
        {
            Debug.Log("winner"); //Might need to add a wait on this! goes to next level too quick
            SceneManager.LoadScene(nextLevel);
        }
    }

    public void record()
    {
        if (recording == true)
        {
            recording = false;
            offText.enabled = true;
            onText.enabled = false;

        }
        else{
            count = 0;
            recording = true;
            offText.enabled = false;
            onText.enabled = true;
        }

    }
    public void playMelody()
    {
        if(chances > 0)
        {
            audioSource.clip = melody;
            audioSource.Play();
            chances--;
        }
        if(chances <= 0)
        {
            melodyButton.interactable = false;
        }

    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
