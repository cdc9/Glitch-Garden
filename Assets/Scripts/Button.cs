using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;  
    public static GameObject selectedDefender;

    private Button[] buttonArray;
    private Text costText;

    // Use this for initialization
    void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();  //Count all of the buttons and add them to the button array

        costText = GetComponentInChildren<Text>();  //Grab the numerical cost of the defender and show it to the player
        if (!costText)
        {
            Debug.LogWarning(name + " there is no cost text");
        }
        costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();  //Set the cost to an actual number
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnMouseDown()
    {

        foreach (Button thisButton in buttonArray) //For each button, turn their color to black
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;  //On click, change from black silhoutte to visible and select the defender
        selectedDefender = defenderPrefab;
        print(selectedDefender);
    }

}
