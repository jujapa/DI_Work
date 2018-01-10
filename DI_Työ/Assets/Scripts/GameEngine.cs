using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

    public GameObject mapObject;
    public GameObject closeProgramWindow;
    //public GameObject cameraObject;

	// Use this for initialization
	void Start () {
        mapObject.SetActive(false);
        //cameraObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Escape))
        {
            /*
            if(closeProgramWindow.activeSelf == true)
            {
                closeProgramWindow.SetActive(true);
            }
            */

            if(closeProgramWindow.activeSelf == true)
            {
                closeProgramWindow.SetActive(false);
            }
            else
            {
                closeProgramWindow.SetActive(true);
            }
        }

        if (Input.deviceOrientation == DeviceOrientation.FaceUp)
        {
            if (mapObject.activeSelf == false)//replaced active with activeSelf
            {
                mapObject.SetActive(true);
            }
        }
        else
        {
            if(mapObject.activeSelf == true)//replaced active with activeSelf
            {
                mapObject.SetActive(false);
            }
        }

	}
}
