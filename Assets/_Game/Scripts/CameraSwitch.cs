using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public Camera frontCam;
    public Camera backCam;
    public float perspectiveValue = 1f;

    public GameObject frontBackgrounds;
    public GameObject backBackgrounds;

     void Start()
    {
        frontCam.enabled = true;
        backCam.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (frontCam.enabled)
            {
                backCam.enabled = true;
                backBackgrounds.SetActive(true);
                perspectiveValue = -1;
                frontCam.enabled = false;
                frontBackgrounds.SetActive(false);

            }
            else if (!frontCam.enabled)
            {
                backCam.enabled = false;
                backBackgrounds.SetActive(false);
                frontCam.enabled = true;
                frontBackgrounds.SetActive(true);

                perspectiveValue = 1;
            }
        }
    }


}

