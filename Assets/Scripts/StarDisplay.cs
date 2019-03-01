using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

    public enum Status { SUCCESS, FAILURE };
    private int totalStars = 1000;

    private Text starText;
    
	// Use this for initialization
	void Start () {
        starText = GetComponent<Text>();
        UpdateDisplay();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars(int amount)
    {
        totalStars += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount)
    {
        if(totalStars >= amount)
        {
            totalStars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        else
        {
           return Status.FAILURE;
        }
        
    }

    private void UpdateDisplay()
    {
        starText.text = totalStars.ToString();
    }
}
