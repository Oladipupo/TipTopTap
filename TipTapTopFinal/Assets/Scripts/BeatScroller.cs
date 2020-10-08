using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public AudioSource song;
    public bool hasStarted;
    public GameObject bunny1;
    public GameObject bunny2;
    public Text startText;
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = (beatTempo / 60f)*2;
        startText.GetComponent<Text>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
                song.Play();
                bunny1.GetComponent<Animation>().Play("Scene");
                bunny2.GetComponent<Animation>().Play("Scene");
                startText.GetComponent<Text>().enabled = false;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, 0f, beatTempo * Time.deltaTime);
        }
    }
}
