using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Defender : MonoBehaviour {

    public int starCost = 100;
    public GameObject upgradedDefender;

    private StarDisplay starDisplay;
    private Vector2 upgradedTowersPosition;
    private GameObject defenderParent;
    private Upgrade upgrade;

    void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        upgrade = GameObject.FindObjectOfType<Upgrade>();
        upgradedTowersPosition = gameObject.transform.position;


        defenderParent = GameObject.Find("Defenders");

        //Creating a defender object to hold all newly spawned defenders. Keeps the heiarchy cleaner
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }

    }
    //Add stars to the total stars
    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }

    //THIS IS FOR UPGRADING TOWER. First pass this defender's position and upgraded defender associated with it. Then Destroy it. 
    public void OnMouseDown()
    {
        upgrade.UpgradeTower(upgradedTowersPosition, upgradedDefender);
        Destroy(gameObject);
    }    
}
