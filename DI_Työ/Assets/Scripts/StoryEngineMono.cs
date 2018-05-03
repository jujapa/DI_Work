using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoryEngineMono : MonoBehaviour {

    public StoryEngine.Location previousLocation = StoryEngine.Location.NoLocation;
    public StoryEngine.Location lastLocation = StoryEngine.Location.NoLocation;
    //public List<StoryEngine.Location> visitedLocations = new List<StoryEngine.Location>();
    public bool[] visitedLocationsBoolean = new bool[] { false, false, false, false, false, false };
    //public StoryEngine.Location[] visitedLocations;
    public bool testing;
    private string[] factoids = new string[] { "Coffee room is at the other side.", "This is the place of futuristic learning in modern times.", "This is the fourth floor.", "Agora was known as Facility of Natural Sciences 2.", "Agora's renovation was completed 2017." };
    private string[] locationAdvice = new string[] {"Try any location", "Try location 1", "Try location 2", "Try location 3", "Try location 4", "Try location 5" };
    //private List<string> advicePool;
    private List<int> adviceIndex = new List<int>();

    // Use this for initialization
    void Start()
    {
        //Add nolocation as a visited location as it's no location
        //visitedLocations.Add(StoryEngine.Location.NoLocation);
        visitedLocationsBoolean[(int)StoryEngine.Location.NoLocation] = true;
        lastLocation = StoryEngine.Location.NoLocation;
        previousLocation = StoryEngine.Location.NoLocation;
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

        //Sets visited location flag to true
        visitedLocationsBoolean[(int)loc] = true;

        //updates location
        //Last change in evening
        if (lastLocation == StoryEngine.Location.NoLocation)
        {
            previousLocation = StoryEngine.Location.NoLocation;
            lastLocation = loc;
            CheckForLocation(loc);
            //visitedLocations.Add(loc);
        }
        else
        {
            if (loc != lastLocation)
            {
                previousLocation = lastLocation;
                lastLocation = loc;
                //visitedLocations.Add(loc);
                CheckForLocation(loc);
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
                        createdText += "Pre 1";
                        break;
                    }
                case 2:
                    {
                        createdText += "Pre 2";
                        break;
                    }
                case 3:
                    {
                        createdText += "Pre 3";
                        break;
                    }
                case 4:
                    {
                        createdText += "Pre 4";
                        break;
                    }
                case 5:
                    {
                        createdText += "Pre 5";
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
                        createdText += " Main Body 1";
                        break;
                    }

                //Tree
                case 2:
                    {
                        createdText += " Main Body 2";
                        break;
                    }

                //Rock case
                case 3:
                    {
                        createdText += " Main Body 3";
                        break;
                    }

                //Chip case
                case 4:
                    {
                        createdText += " Main Body 4";
                        break;
                    }

                //Asphalt case
                case 5:
                    {
                        createdText += " Main Body 5";
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

        //add random advice for nex location
        //Causes error
            createdText += " " + generateRandomLocationAdvice();

            #region old_random_advice_implementation
            /*
             * old and bugged
            //add advice for next location
            for (int x = 0; x < visitedLocations.Count; x++)
            {
                foreach(StoryEngine.Location temp in Enum.GetValues(typeof(StoryEngine.Location)))
                {
                    if(visitedLocations[x] != temp)
                    {
                        advicePool.Add(locationAdvice[(int)visitedLocations[x]]);
                    }
                }    
            }

            if (advicePool[0] != null)
            {
                createdText += advicePool[UnityEngine.Random.Range(0, advicePool.Count - 1)];
            }
            else
            {
                createdText += " You have visited all locations.";
            }
            //Untested ends
            */
            #endregion



        }//End of test text generator

        //Part for generating real case texts
        else
        {
            createdText = "Real test Text StoryEngine.";
        }//End of real use test generator

        return createdText;




    }

    //Possibly unnessesary
    //Under Testing...
    //Bugged in var1!=var2
    //Causes multible entriest at the time instead of blocking dublicates
    public void CheckForLocation(StoryEngine.Location loc)
    {
            visitedLocationsBoolean[(int)loc] = true;

        #region old_implementation
        //visitedLocations.Add(loc);
        /*
        //Old implementation
        if(visitedLocations.Count >= 0)
        {
            Debug.Log("CheckForLocations debug.");
            Debug.Log((int)loc);

            if (visitedLocationsBoolean[(int)loc] == false)
            {
                //visitedLocations.Add(loc);
                visitedLocationsBoolean[(int)loc] = true;
            }
        }
        */
        /*
        //Old
        if (visitedLocations.Count != 0)
        {
            Debug.Log("CheckForLocations debug.");
            
            //bugged adds too many
            for (int i = 0; i <= visitedLocations.Count - 1; i++)
            {
                string var1 = Enum.GetName(typeof(StoryEngine.Location), visitedLocations[i]);
                Debug.Log(var1);
                string var2 = Enum.GetName(typeof(StoryEngine.Location), loc);
                Debug.Log(var2);
                if (var1 != var2)
                {
                    visitedLocations.Add(loc);
                }
            }    
        }
        else
        {
            visitedLocations.Add(loc);
        }
        */
        #endregion
    }


    #region old_function
    //Untested function
    //Old Function
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
    #endregion


    /// <summary>
    /// Generates Random Location Advice from non visited locations
    /// </summary>
    /// <returns> advice String </returns>
    public string generateRandomLocationAdvice()
    {
        string advice = "";

        for (int i = 0; i <= visitedLocationsBoolean.Length - 1; ++i)
        {
            if (visitedLocationsBoolean[i] == false)
            {
                adviceIndex.Add(i);
                break;
            }
        }

        int randomIndex = UnityEngine.Random.Range(0, adviceIndex.Count - 1);
        /*
        Debug.Log("adviceIndex Count: " + adviceIndex.Count);
        Debug.Log("locationAdvice lenght: " + locationAdvice.Length);
        Debug.Log("randomIndex: " + randomIndex); //*Possibly fixed* Random index can go over locationAdvice lenght. >> adviceIndex.Count can go over 6
        */
        advice = locationAdvice[randomIndex]; //*Possibly fixed* Causes exception: System.IndexOutOfRangeException: Array index is out of range.

        return advice;
    }

    #region unnessessary_function
    /*
    //Untested function
    //Unnessessary in new implementation
    //Old method
    //Sees if given loc is found in visitedLocations list. Returns bool
    public Boolean CheckForVisitedLocation(StoryEngine.Location loc)
    {
        bool result = false;

       for(int i = 0; i < visitedLocations.Count; i++)
        {
            if(loc == visitedLocations[i])
            {
                result = true;
                break;
            }
        }
        return result;
    }*/
    #endregion


    public void UpdateLocation(StoryEngine.Location loc)
    {
        if (loc != lastLocation)
        {
            previousLocation = lastLocation;
            lastLocation = loc;
        }



    }

    //For editor testing
#if UNITY_EDITOR

    //to print visited locations list to console
    /*
     * Old method. Doesn't work in current implementation
    public void DebugPrint()
    {
       for(int x = 0; x < visitedLocations.Count; x++)
        {
            StoryEngine.Location debugLoc = visitedLocations[x];
            string debugText = Enum.GetName(typeof(StoryEngine.Location), debugLoc);//Gets name from given enum

            Debug.Log("Visited Location: " + debugText);
        }     
    }
    */

#endif

}//End of Class
