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
    private int count = 0;
    private bool wrong = false;
    private bool recording = false;
    public AudioClip[] notesSounds;
    public AudioSource audioSource;
    public AudioClip melody;
    public AudioClip wrongSound;
    public AudioClip wonSound;
    public Text onText;
    public Text offText;
    public Button melodyButton;
    public string nextLevel;
    private string buttonString;
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
            input_sequence = new int [totalNotesInSequence];
            Debug.Log(input_sequence[0]);
            audioSource.clip = wrongSound;
            audioSource.Play();
            wrong = false;
        }
        else
        {
            melodyButton.interactable = false; 
            audioSource.clip = wonSound;
            audioSource.Play();
            StartCoroutine(waiterWin());  
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
            input_sequence = new int[totalNotesInSequence];
            recording = true;
            offText.enabled = false;
            onText.enabled = true;
        }

    }
    public void playMelody()
    {
        recording = false;
        offText.enabled = true;
        onText.enabled = false;
        StartCoroutine(waiter());     
    }

    IEnumerator waiterWin(){       
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(nextLevel);
    }
    IEnumerator waiter(){
        melodyButton.interactable = false;
        for(int i = 0; i < totalNotesInSequence; i++){
                audioSource.clip = notesSounds[correct_sequence[i]];
                audioSource.Play();
                int x = correct_sequence[i] + 1;
                buttonString = "Button_" + x.ToString();
                Button buttonClick = GameObject.FindGameObjectWithTag(buttonString).GetComponent<Button>();
                buttonClick.interactable = false;
                yield return new WaitForSeconds(0.5f);
                buttonClick.interactable = true;
                yield return new WaitForSeconds(0.5f);
            }
        melodyButton.interactable = true;
       
    }
    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
