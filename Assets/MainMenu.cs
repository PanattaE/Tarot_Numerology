using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {


    public GameObject MainMenuCanvas;
    public GameObject TR;
    public GameObject TR_TarotReading;
    public GameObject TR_TheCut;
    public GameObject KYPS;
    public GameObject KYPS_KYPSGen;
    public GameObject KYPS_Results;

    public void OnKYPSSelect()
    {
        MainMenuCanvas.SetActive(false);
        KYPS.SetActive(true);
        KYPS_KYPSGen.SetActive(true);
        KYPS_Results.SetActive(false);
    }
    public void OnTRSelect()
    {
        MainMenuCanvas.SetActive(false);
        TR.SetActive(true);
        TR_TheCut.SetActive(true);
        TR_TarotReading.SetActive(false);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
