using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); //Keeps the music player from scene to scene
        Debug.Log("Don't destroy on load" + name);
    }
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPerfManager.GetMasterVolume();
    }

    private void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level]; //Set variable to current music clip based on level
        Debug.Log("playing clip for: " + thisLevelMusic);    

        if (thisLevelMusic) //If there is some music attached
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    //This will set the volume of the music to whatever value you put in there
    public void SetVolume(float volumeValue)
    {
        audioSource.volume = volumeValue;
    }
}
