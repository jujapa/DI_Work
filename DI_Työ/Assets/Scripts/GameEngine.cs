using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

    public GameObject mapObject;
    public GameObject closeProgramWindow;
    public StoryEngineMono storyEngineInstance;
    //public GameObject cameraObject;

    private float buttonCooldownTime = 2.0f;
    private float currentCooldownTime = 0.0f;

	// Use this for initialization
	void Start () {
        mapObject.SetActive(false);
        storyEngineInstance = GameObject.FindGameObjectWithTag("StoryEngine").GetComponent<StoryEngineMono>();
        //cameraObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if(closeProgramWindow.activeSelf == true)
            {
                closeProgramWindow.SetActive(false);
            }
            else
            {
                closeProgramWindow.SetActive(true);
            }
        }

#if UNITY_ANDROID
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
#endif


#if UNITY_EDITOR
        
        #region testing_inputs

        if (Input.GetKeyDown(KeyCode.F5))
        {
            //storyEngineInstance.DebugPrint();
        }

        if (Input.GetKeyDown(KeyCode.F9))
        {
            Debug.Log("F9 Pressed. Non Functional.");
        }

        if (Input.GetKey(KeyCode.M))
        {
            //mapObject.SetActive(!mapObject.activeSelf);
            
            if (mapObject.activeSelf == false)
            {
                    mapObject.SetActive(true);
            }
            else
            {
                    mapObject.SetActive(false);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (currentCooldownTime <= 0.0f)
            {
                storyEngineInstance.CheckForLocation(StoryEngine.Location.Asphalt);
                currentCooldownTime = buttonCooldownTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (currentCooldownTime <= 0.0f)
            {
                storyEngineInstance.CheckForLocation(StoryEngine.Location.Asphalt);
                currentCooldownTime = buttonCooldownTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (currentCooldownTime <= 0.0f)
            {
                storyEngineInstance.CheckForLocation(StoryEngine.Location.Asphalt);
                currentCooldownTime = buttonCooldownTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (currentCooldownTime <= 0.0f)
            {
                storyEngineInstance.CheckForLocation(StoryEngine.Location.Asphalt);
                currentCooldownTime = buttonCooldownTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            if (currentCooldownTime <= 0.0f)
            {
                storyEngineInstance.CheckForLocation(StoryEngine.Location.Asphalt);
                currentCooldownTime = buttonCooldownTime;
            }
        }

        currentCooldownTime -= Time.deltaTime;
        //Debug.Log(string.Format("{0:N4}", currentCooldownTime));
        #endregion
#endif
    }
}
