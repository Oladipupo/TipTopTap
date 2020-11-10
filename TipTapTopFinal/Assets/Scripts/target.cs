using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public KeyCode button;
    public KeyCode button2;
    public GameObject note;
    public bool isOnTarget;
    public GameObject sceneController;
    private GameObject currentNote;
    //Hit or miss sound
    public AudioSource audioS;
    public AudioClip hitTarget;
    public AudioClip missTarget;

    //Make sparks fly when you hit the target
    private ParticleSystem ps;

    //make the clicker smaller when the player press down
    private Transform trans;
    private float duration = 0.1f;
    private float elapsedTime = 10.0f;
    private Vector3 scale;
	
    private bool lastOne =false;
    public bool badNote = false;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
        trans = GetComponent<Transform>();
        scale = trans.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnTarget)
        {

            if (Input.GetKeyDown(button) || Input.GetKeyDown(button2))
            {
                if (badNote)
                {
                    //scale
                    elapsedTime = 0.0f;

                    //play miss
                    audioS.clip = missTarget;
                    audioS.Play();
                    Destroy(currentNote.gameObject);
                    sceneController.GetComponent<SceneController>().inARow = 0;
                    sceneController.GetComponent<SceneController>().updateScore(-5); //not sure if we want to take away points
                }
                else
                {
                    //play hit
                    audioS.clip = hitTarget;
                    audioS.Play();
                    //play sparks 
                    ps.Play();

                    //scale
                    elapsedTime = 0.0f;

                    sceneController.GetComponent<SceneController>().inARow += 1;

                    Destroy(currentNote.gameObject);
                    sceneController.GetComponent<SceneController>().updateScore(20);
                    isOnTarget = false;
                    if (lastOne)
                    {
                        StartCoroutine(delayEndGame());
                        sceneController.GetComponent<SceneController>().EndGame();

                    }
                }

            }
        }
        else
        {
            
            if (Input.GetKeyDown(button) || Input.GetKeyDown(button2))
            {
                //scale
                elapsedTime = 0.0f;
                
                //play miss
                audioS.clip = missTarget;
                audioS.Play();
                sceneController.GetComponent<SceneController>().inARow = 0;
                sceneController.GetComponent<SceneController>().updateScore(-5); //not sure if we want to take away points


          
            }
        }

        if(elapsedTime < duration){
                    trans.localScale = new Vector3(scale.x/2, scale.y, scale.z/2);
                    elapsedTime += Time.deltaTime;
                    
                }
        else{
                trans.localScale = scale;
            }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Last One")
		{
			lastOne = true;
		}
        if(other.gameObject.tag == "badNote")
        {
            badNote = true;
        }
        isOnTarget = true;
        currentNote = other.gameObject;

        
    }
    void OnTriggerExit(Collider other)
    {

        isOnTarget = false;
        currentNote = null;
		if (lastOne)
		{
			StartCoroutine(delayEndGame());
            sceneController.GetComponent<SceneController>().EndGame();

		}
        if (badNote)
        {
            badNote = false;
        }

    }

    IEnumerator delayEndGame()
	{
		yield return new WaitForSeconds(5);
		
	}

}