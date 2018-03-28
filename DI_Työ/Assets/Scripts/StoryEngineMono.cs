using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoryEngineMono : MonoBehaviour {

    public StoryEngine.Location previousLocation;
    public StoryEngine.Location lastLocation;
    public StoryEngine.Location[] visitedLocations;
    public bool testing;
    private string[] factoids = new string[] { "Coffee room is at the other side.", "This is the place of futuristic learning in modern times.", "This is the fourth floor.", "Agora was known as Facility of Natural Sciences 2.", "Agora's renovation was completed 2017." };
    private string[] locationAdvice = new string[] { "Try location 1", "Try location 2", "Try location 3", "Try location 4", "Try location 5" };
    private List<string> advicePool;

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


        if (testing)
        {

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
                case 3:
                    {
                        createdText += "Pre 2";
                        break;
                    }
                case 4:
                    {
                        createdText += "Pre 3";
                        break;
                    }
                case 5:
                    {
                        createdText += "Pre 4";
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

                //NoLocation case
                case 0:
                    {
                        createdText += "NoLocation";
                        break;
                    }

                //Building case
                case 1:
                    {
                        createdText += " Main Body 0";
                        break;
                    }

                //Tree
                case 2:
                    {
                        createdText += " Main Body 1";
                        break;
                    }

                //Rock case
                case 3:
                    {
                        createdText += " Main Body 1";
                        break;
                    }

                //Chip case
                case 4:
                    {
                        createdText += " Main Body 1";
                        break;
                    }

                //Asphalt case
                case 5:
                    {
                        createdText += " Main Body 1";
                        break;
                    }

                //Default case
                default:
                    {
                        createdText += " Main Body default";
                        break;
                    }


            }

            
            //Untested Starts
            //add advice for next location
            for (int x = 0; x < visitedLocations.Length; x++)
            {
                foreach(StoryEngine.Location temp in Enum.GetValues(typeof(StoryEngine.Location)))
                {
                    if(visitedLocations[x] != temp)
                    {
                        advicePool.Add(locationAdvice[(int)visitedLocations[x]]);
                    }
                }    
            }

            createdText += advicePool[UnityEngine.Random.Range(0, advicePool.Count - 1)];
            //Untested ends





        }//End of test text generator

        else
        {
            createdText = "Real test Text StoryEngine.";
        }//End of real use test generator

        return createdText;




    }

    //Possibly unnessesary
    public void CheckForLocation(StoryEngine.Location loc)
    {
        
        for (int i = 0; i < visitedLocations.Length; i++)
        {
            
        }
    }

    /*
    //Untested function
    //Sees if given loc is found in given list. Returns bool
    public Boolean CompareToLocationEnum(StoryEngine.Location loc, StoryEngine.Location[] locList)
    {
        bool result = false;

        foreach (StoryEngine.Location locat in Enum.GetValues(typeof(StoryEngine.Location)))
        {
            if(locat == loc)
            {
                result = true;
                break;
            }

            
        }

        return result;
    }
    */


    //Untested function
    //Sees if given loc is found in visitedLocations list. Returns bool
    public Boolean CheckForVisitedLocation(StoryEngine.Location loc)
    {
        bool result = false;

       for(int i = 0; i < visitedLocations.Length; i++)
        {
            if(loc == visitedLocations[i])
            {
                result = true;
                break;
            }
        }
        return result;
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
