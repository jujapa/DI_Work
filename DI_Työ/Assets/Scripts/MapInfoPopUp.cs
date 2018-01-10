using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapInfoPopUp : MonoBehaviour {

    public GameObject image;
    public GameObject indicator;

	// Use this for initialization
	void Start () {
        image.SetActive(false);
        indicator.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClicked()
    {
        
        image.SetActive(!image.activeSelf);
        indicator.SetActive(!indicator.activeSelf);
        
        /*
         * //old code
        gameObject.GetComponentInChildren<MapInfoPopUpImage>().gameObject.SetActive(!gameObject.GetComponentInChildren<MapInfoPopUpImage>().gameObject.activeSelf);
        gameObject.GetComponentInChildren<MapInfoPopUpIndicator>().gameObject.SetActive(!gameObject.GetComponentInChildren<MapInfoPopUpIndicator>().gameObject.activeSelf);
        */
    }
}
