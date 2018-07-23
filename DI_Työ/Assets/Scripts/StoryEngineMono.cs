using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoryEngineMono : MonoBehaviour {

    public StoryEngine.Location previousLocation = StoryEngine.Location.NoLocation;
    public StoryEngine.Location lastLocation = StoryEngine.Location.NoLocation;

    public StoryEngine.RealLocation realPreviousLocation = StoryEngine.RealLocation.NoLocation; // added for real case
    public StoryEngine.RealLocation realLastLocation = StoryEngine.RealLocation.NoLocation; // Added for real case

    //public List<StoryEngine.Location> visitedLocations = new List<StoryEngine.Location>();
    public bool[] visitedLocationsBoolean = new bool[] { false, false, false, false, false, false };
    public bool[] realVisitedLocationsBoolean = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
    //public StoryEngine.Location[] visitedLocations;
    public bool testing;
    //Testing Values
    public string[] factoids = new string[] { "Coffee room is at the other side.", "This is the place of futuristic learning in modern times.", "This is the fourth floor.", "Agora was known as Facility of Natural Sciences 2.", "Agora's renovation was completed 2017." };
    private string[] locationAdvice = new string[] {"Try any location", "Try location 1", "Try location 2", "Try location 3", "Try location 4", "Try location 5" };
    //Real Values
    public string[] RealFactoids = new string[] { "Coffee room is at the other side.", "This is the place of futuristic learning in modern times.", "This is the fourth floor.", "Agora was known as Facility of Natural Sciences 2.", "Agora's renovation was completed 2017." };
    private string[] RealLocationsAdvice = new string[] {"Käy missä vain.",
        "Seuraavaksi voitte käydä alulassa haukkaamassa raittiimpaa ilmaa.", "Seuraavaksi voitte käydä katsomassa MR-labraa (453).",
        "Seuraavaksi voitte käydä Terveysteknologian toimipisteellä. (452D)",
        "Elektroniikan tyyssia on mahdollinen seuraava vierailupaikka. (452C)",
        "Voit käydä vierailemassa tekoälytutkinnan labralla. (452B)",
        "Pelikehityksen tutkimusta tehdään huoneessa 452A.",
        "Seuraavaksi voit käydä ViLLE oppimisjärjestelmän kehittäneiden toimipisteellä. (451G)",
        "Neuroverkkoja löytyy huoneesta 451A.",
        "Seuraavaksi voit käydä Bioinformatiikan paikalla. (450K)",
        "Voit mennä käymään seuraavaksi kahvihuoneen yhteydessä oleville neuvotteluhuoneille.",
        "Kahvihuone löytyy eteläpuolen keskeltä, kuin sydän yksikölle. Sinne on aina hyvä mennä." };    
    
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
            #region testing
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

        //add random advice for nex location

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


            #endregion
        }//End of test text generator


        //Part for generating real case texts
        else
        {
            
        }//End of real use test generator

        return createdText;

    }

    /// <summary>
    /// Returns text for the needed location
    /// </summary>
    /// <returns></returns>
    /// Added for real case
    public string CreateInfoText(StoryEngine.RealLocation loc)
    {

        //Sets visited location flag to true
        realVisitedLocationsBoolean[(int)loc] = true;

        //updates location
        //Last change in evening
        if (realLastLocation == StoryEngine.RealLocation.NoLocation)
        {
            realPreviousLocation = StoryEngine.RealLocation.NoLocation;
            realLastLocation = loc;
            CheckForLocation(loc);
            //visitedLocations.Add(loc);
        }
        else
        {
            if (loc != realLastLocation)
            {
                realPreviousLocation = realLastLocation;
                realLastLocation = loc;
                //visitedLocations.Add(loc);
                CheckForLocation(loc);
            }
        }


        //Temp text
        string createdText = "";


        int l = (int)realLastLocation;
        int p = (int)realPreviousLocation;


        if (testing)
        {

        }//End of test text generator

        //Part for generating real case texts
        else
        {
            //createdText = "Real test Text StoryEngine.";
            //Pre text
            switch (p)
            {
                case 0:
                    {
                        createdText += "Tämä on ensimmäinen paikkanne?";
                        break;
                    }
                case 1:
                    {
                        createdText += "Tämä on Agoran neljännen kerroksen aula. Opatus keskittyy eteläpuoleen, jossa suurin osa tutkimusryhmien tiloista on.";
                        break;
                    }
                case 2:
                    {
                        createdText += "";
                        break;
                    }
                case 3:
                    {
                        createdText += "";
                        break;
                    }
                case 4:
                    {
                        createdText += "";
                        break;
                    }
                case 5:
                    {
                        createdText += "Tekoälyn tutkinnassa ei ollut mitään ihmeellistä… Eihän.";
                        break;
                    }
                case 6:
                    {
                        createdText += "";
                        break;
                    }
                case 7:
                    {
                        createdText += "";
                        break;
                    }
                case 8:
                    {
                        createdText += "";
                        break;
                    }
                case 9:
                    {
                        createdText += "";
                        break;
                    }
                case 10:
                    {
                        createdText += "Kokoushuoneet olivat mukavan näköisiä, mutta jatketaan.";
                        break;
                    }
                case 11:
                    {
                        createdText += "Kahvihuoneesta on aina harmi lähteä, mutta kierroksen on jatkuttava.";
                        break;
                    }
                default:
                    {
                        createdText += "Olitte jossain... Olittehan?";
                        break;
                    }

            }

            //Main body of text
            switch (l)
            {

                //NoLocation case
                case 0:
                    {
                        //checks if the place has been visited before
                        if (realVisitedLocationsBoolean[0])
                        {
                            createdText += "NoLocation... Again";
                            break;
                        }
                        else {

                        createdText += "NoLocation";
                        break;
                        }
                    }

                //
                case 1:
                    {
                        //checks if the place has been visited before
                        if (realVisitedLocationsBoolean[1])
                        {
                            createdText += "Olette jälleen aulassa.";
                            break;
                        }
                        else
                        {

                            createdText += "Tämä on Agoran neljännen kerroksen aula. Opatus keskittyy eteläpuoleen, jossa suurin osa tutkimusryhmien tiloista on.";
                            break;
                        }
                    }

                //
                case 2:
                    {
                        //checks if the place has been visited before
                        if (realVisitedLocationsBoolean[2])
                        {
                            createdText += "Vielä ei ole aika VR-kierrokselle. Ehkä vielä myöhemmin.";
                            break;
                        }
                        else
                        {

                            createdText += "Tämä on MR labra. Täällä tehdään uraauurtavaa lisätyn- ja virtuaalitodellisuuden tutkimusta. Tämä on suosittu kohde laitoksen vieraille. Tarvitsette luvan päästä kokeilemaan VR-laseja. Ehkä myöhemmin.";
                            break;
                        }
                    }

                //
                case 3:
                    {
                        //checks if the place has been visited before
                        if (realVisitedLocationsBoolean[3])
                        {
                            createdText += "Ilmaiskappaleita sensoreista ei ole suoraan saatavilla.";
                            break;
                        }
                        else
                        {

                            createdText += "Täällä työskennellään terveysteknologioiden parissa. Tutkimusta tehdään monitieteellisessä yhteistyössä. Esimerkiksi Mikko Pänkäällän tutkimusryhmä on tehnyt ei-invasiivisia, liikeantureihin perustuvia sydämen telemonitorointitekniikoita.";
                            break;
                        }
                    }

                //
                case 4:
                    {
                        //checks if the place has been visited before
                        if (realVisitedLocationsBoolean[4])
                        {
                            createdText += "Unohdin mainita Insinööri Opetustutkimuksesta. Sitä tehdään täällä.";
                            break;
                        }
                        else
                        {

                            createdText += "Sulautettut elektroniikan tutkimus keskittyy täällä “Internet of Things” tutkimukseen, rinnakkais Arkkitehtuureihin ja itsenäisiin sulautettuihin elektroniikkaan. Tilassa työskentelee myös tekoälytutkijoita.";
                            break;
                        }
                    }

                //
                case 5:
                    {
                        //checks if the place has been visited before
                        if (realVisitedLocationsBoolean[5])
                        {
                            createdText += "Skynetin tuleminen ei ole vielä tänään, niin voitte rauhoittua… Luotathan minuun?";
                            break;
                        }
                        else
                        {

                            createdText += "Huoneessa on tietojenkäsittelytieteen tutkijoita tekemässä Data-analytiikaa ja tekoälytutkimusta. Laboratorion tutkimus keskittyy algoritmisuunnittelun ja koneellisenälyn metodeihin ja tekniikoihin.";
                            break;
                        }
                    }

                //
                case 6:
                    {
                        //checks if the place has been visited before
                        if (realVisitedLocationsBoolean[6])
                        {
                            createdText += "Ohjelmistotekniikassa tutkitaan yleisesti ohjelmisto- ja pelikehitystä. Tutkimusta suoritti ennen TUCS:n ohjelmisto kehityslaboratorio(SwDev). ";
                            break;
                        }
                        else
                        {

                            createdText += "Ohjelmistotekniikka ei ole ehtinyt uudistumaan näin nopeasti huolimatta alan maineesta nopeaan kehitykseen.";
                            break;
                        }
                    }
                //
                case 7:
                    {
                        //checks if the place has been visited before
                        if (realVisitedLocationsBoolean[7])
                        {
                            createdText += "Kehittäjät jatkavat väsymättömästi ViLLE järjestelmän ylläpitoa.";
                            break;
                        }
                        else
                        {

                            createdText += "Oppimisanalytiikan tavoitteena on hyödyntää opiskelijoista tallennetua tietoa opetuksen ja oppimisen kehittämiseen. ViLLE-oppimisjärjestelmä kehitettiin heidän toimestaan.";
                            break;
                        }
                    }
                //
                case 8:
                    {
                        //checks if the place has been visited before
                        if (realVisitedLocationsBoolean[8])
                        {
                            createdText += "Neuroverkot kouluttautuvat aktiivisesti ilman apuanne.";
                            break;
                        }
                        else
                        {

                            createdText += "Kieliteknologian ryhmä kouluttaa neuroverkkoja kielitieteellisiin tutkimustarkoituksiin. Yksikön vetäjä on Filip Ginter.";
                            break;
                        }
                    }
                //
                case 9:
                    {
                        //checks if the place has been visited before
                        if (realVisitedLocationsBoolean[9])
                        {
                            createdText += "Tutkimus jatkuu ja kierros kiertyy itseensä.";
                            break;
                        }
                        else
                        {

                            createdText += "Bioinformaatikassa tutkitaan tällä hetkellä hiili anhydraatteja (carbonic anhydrases). Välitavoitteena tutkimuksella on löytää todennäköisin historia hiili anhydraattien evoluutiolle.";
                            break;
                        }
                    }
                //
                case 10:
                    {
                        //checks if the place has been visited before
                        if (realVisitedLocationsBoolean[10])
                        {
                            createdText += "Tämä ei ole kahvihuone. Eikun on.";
                            break;
                        }
                        else
                        {

                            createdText += "Mänty ja Honka ovat keskeisimmät neuvotteluhuoneet laitoksella. Ne ovat monikäyttöiset ja yhdistettävissä siirrettävien väliseinien kanssa. Niiden läheisyys kahvihuoneeseen tarjoaa mahdollisuuden yhdistää ne suureksi avoimeksi tilaksi.";
                            break;
                        }
                    }
                //
                case 11:
                    {
                        //checks if the place has been visited before
                        if (realVisitedLocationsBoolean[11])
                        {
                            createdText += "Biljardiottelu käytiin 2017, ja uusi on kaukana. Noh. Kahvia on aina… Kai?";
                            break;
                        }
                        else
                        {

                            createdText += "Kokoontumispaikka ja kitkeränhajuisen elämänveden keidas. Kahvihuone on enemmän tai vähemmän tapahtumien tilaisuuspaikka.";
                            break;
                        }
                    }

                //Default case
                default:
                    {
                        createdText += " Jotain kummaa on päässyt tapahtumaan.";
                        break;
                    }


            }

            //add random advice for nex location

            createdText += " " + generateRandomLocationAdvice();

        }//End of real use test generator

        return createdText;




    }

    //Possibly unnessesary
    //Under Testing...
    //Bugged in var1!=var2
    //Causes multible entriest at the time instead of blocking dublicates
    //possibly working now
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

    //Possibly unnessesary
    //Under Testing...
    //Bugged in var1!=var2
    //Causes multible entriest at the time instead of blocking dublicates
    //Possibly working now
    //Added for real case
    public void CheckForLocation(StoryEngine.RealLocation loc)
    {
        visitedLocationsBoolean[(int)loc] = true;

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
        if (adviceIndex.Count != 0) {
            int randomIndex = UnityEngine.Random.Range(0, adviceIndex.Count - 1);
            #region Debug
            /*
            //Debug.Log("adviceIndex Count: " + adviceIndex.Count);
            //Debug.Log("locationAdvice lenght: " + locationAdvice.Length);
            //Debug.Log("randomIndex: " + randomIndex); //*Possibly fixed* Random index can go over locationAdvice lenght. >> adviceIndex.Count can go over 6
            */
            #endregion
            advice = locationAdvice[randomIndex];
        }
        else
        {
            advice = "All Locations are visited.";
        }
            
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

    //BackUp of an old implementation of text generation
    /*
     * 
     * //Pre text
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

        //add random advice for nex location

            createdText += " " + generateRandomLocationAdvice();

            
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



            #endregion
     */

}//End of Class
