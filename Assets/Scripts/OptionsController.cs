using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
    
    //Creating public sliders to put in Unity
    public Slider volumeSilder;
    public Slider difficultySilder;

    public LevelManager levelManager;

    private MusicManager musicManager;
	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();

        //Set the values of the sliders to whatever the volume/difficulty was set to before
        volumeSilder.value = PlayerPerfManager.GetMasterVolume();
        difficultySilder.value = PlayerPerfManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
        musicManager.SetVolume(volumeSilder.value);
    }

    //Save the settings for the user like volume and difficulty and exit the options menu
    public void SaveAndExit()
    {
        PlayerPerfManager.SetMasterVolume(volumeSilder.value);
        PlayerPerfManager.SetDifficulty(difficultySilder.value);
        levelManager.LoadLevel("01a_Start");
    }

    //This will be the default values for the volume and the difficulty
    public void SetDefaults()
    {
        volumeSilder.value = 0.8f;
        difficultySilder.value = 2f; 
    }
    
}
