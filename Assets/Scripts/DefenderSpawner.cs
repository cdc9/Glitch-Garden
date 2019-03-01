using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    
    public Camera myCamera;

    private GameObject defenderParent;
    private StarDisplay starDisplay;

    void Start()
    {
        defenderParent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        //Creating a defender object to hold all newly spawned defenders. Keeps the heiarchy cleaner
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }

    //Tracking when the user clicks the mouse
    void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPositionOfMouseClick(); //Get the raw data first
        Vector2 roundedPos = SnapToGrid(rawPos); //Transform raw data to rounded numbers
        GameObject defender = Button.selectedDefender; //Set defender object to whatever is selected
        

        int defenderCost = defender.GetComponent<Defender>().starCost;
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, defender);
        }
        else
        {
            Debug.Log("Insufficient Stars");
        }
        
    }

    void SpawnDefender (Vector2 roundedPos, GameObject defender)
    {
        Quaternion zeroRotation = Quaternion.identity; //Set rotation to zero
        GameObject newDef = Instantiate(defender, roundedPos, zeroRotation) as GameObject;
        newDef.transform.parent = defenderParent.transform;
    }

    //Method to convert world space data to rounded nice numbers
    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);


        return new Vector2(newX, newY);
    }

    //This is determining where the position of the mouse click is
    Vector2 CalculateWorldPositionOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
        return worldPos;
    }
}
