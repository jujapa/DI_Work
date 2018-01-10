using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEngineMono : MonoBehaviour {

    public StoryEngine.Location previousLocation;
    public StoryEngine.Location lastLocation;
    public StoryEngine.Location[] visitedLocations;



    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Returns text for the needed location
    /// </summary>
    /// <returns></returns>
    public string CreateInfoText(StoryEngine.Location loc)
    {


        //updates location
        //Last change in evening
        if (lastLocation == StoryEngine.Location.NoLocation)
        {
            previousLocation = StoryEngine.Location.NoLocation;
            lastLocation = loc;

        }
        else
        {
            if (loc != lastLocation)
            {
                previousLocation = lastLocation;
                lastLocation = loc;
            }
        }


        //Temp text
        string createdText = "";


        int l = (int)lastLocation;
        int p = (int)previousLocation;


        //Pre text
        switch (p)
        {
            case 0:
                {
                    createdText += "NoLocation";
                    break;
                }
            case 1:
                {
                    createdText += "Pre 0";
                    break;
                }
            case 2:
                {
                    createdText += "Pre 1";
                    break;
                }
            default:
                {
                    createdText += "Pre default";
                    break;
                }

        }

        //Main body of text
        switch (l)
        {

            //building case
            case 0:
                {
                    createdText += "NoLocation";
                    break;
                }

            //Tree case
            case 1:
                {
                    createdText += " Main Body 0";
                    break;
                }

            case 2:
                {
                    createdText += " Main Body 1";
                    break;
                }

            default:
                {
                    createdText += " Main Body default";
                    break;
                }


        }

        return createdText;

        //return "Test text StoryEngine.";
    }

    public void CheckForLocation(StoryEngine.Location loc)
    {
        
        for (int i = 0; i < visitedLocations.Length; i++)
        {
            
        }
    }

    public void UpdateLocation(StoryEngine.Location loc)
    {
        if (loc != lastLocation)
        {
            previousLocation = lastLocation;
            lastLocation = loc;
        }



    }
}
