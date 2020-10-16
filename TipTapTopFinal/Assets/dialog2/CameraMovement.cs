using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        AnimateDown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateDown()
    {
        
        while (mainCam.transform.rotation.x < 33)
        {
            mainCam.transform.Rotate(1.0f, 0.0f, 0.0f);
        }
    }
}
