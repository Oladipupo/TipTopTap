using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteCatcher : MonoBehaviour

{
    public GameObject sceneController;

    public AudioSource audio;
    public AudioClip miss;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        audio.clip = miss;
        audio.Play();

        Destroy(other.gameObject);
        sceneController.GetComponent<SceneController>().updateScore(-10);
        sceneController.GetComponent<SceneController>().inARow = 0;

    }
}
