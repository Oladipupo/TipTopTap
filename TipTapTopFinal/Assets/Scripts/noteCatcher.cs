using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class noteCatcher : MonoBehaviour

{
    public GameObject sceneController;

    public AudioSource audio;
    public AudioClip miss;
    public string currentLevel;
    public int count = 0;
    public float waitTime;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = 4f;
        audio = GetComponent<AudioSource>();
        text.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
      
        if(count == 35){  
             StartCoroutine(waiter());
            }
            
            
    }

    private void OnTriggerEnter(Collider other)
    {
        audio.clip = miss;
        audio.Play();

        count++;

        Destroy(other.gameObject);
        sceneController.GetComponent<SceneController>().updateScore(-10);
        sceneController.GetComponent<SceneController>().inARow = 0;

    }

    IEnumerator waiter(){
        text.text = "MISSED TOO MANY NOTES. RESTARTING";
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(currentLevel);
    }
}
