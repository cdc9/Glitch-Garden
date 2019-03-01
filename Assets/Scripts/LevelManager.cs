using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadLevelAfter;
	// Use this for initialization
	void Start () {
        if(autoLoadLevelAfter <= 0)
        {
            Debug.Log("Level auto load disabled, use a positive number in seconds");
        }
        else{
            Invoke("LoadNextLevel", autoLoadLevelAfter);
        }
        
	}

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for " + name);
        //Application.LoadLevel(name); <-- Obsolete 
        SceneManager.LoadScene(name);
    }

    public void QuitLevel(string name)
    {
        Debug.Log("Quit game requested for " + name);
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
		
	}

    //This grabs the next level in the build queue and changes the level accordingly
    public void LoadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
