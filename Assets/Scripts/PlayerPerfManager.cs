using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPerfManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFF_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    
    //Set the master volume for the player
    public static void SetMasterVolume(float volume)
    {
        if(volume >= 0f && volume <= 1f )
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range");
        }
       
    }

    //Retrieve the master volume for the player
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1) 
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //Use 1 for true
        }
        else
        {
            Debug.Log("Trying to unlock level not in build order");
        }
    }

    //Determines how many levels the player has unlocked and has access to
    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);


        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            return isLevelUnlocked;
        }
        Debug.Log("The Level number does not exist in the list!");
        return false;        
    }

    //Set the difficulty for the player
    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFF_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range");
        }
    }

    //Retrieve the difficulty value for the player
    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFF_KEY);
    }
}
