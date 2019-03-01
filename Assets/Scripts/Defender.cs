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

    //THIS IS FOR UPGRADING TOWER
    public void OnMouseDown()
    {
        if (upgrade.isUpgradeSelected && upgrade.upgradeCount >= 1)
        {
            SpawnDefender(upgradedTowersPosition, upgradedDefender);
            Destroy(gameObject);
            upgrade.UpgradeSelectedTower();
        }
        else
        {
            Debug.Log("Couldn't summon upgraded tower");
        }
    }

    void SpawnDefender(Vector2 upgradedTowersPosition, GameObject upgradedDefender)
    {
        Quaternion zeroRotation = Quaternion.identity; //Set rotation to zero
        GameObject newUpgradedDef = Instantiate(upgradedDefender, upgradedTowersPosition, zeroRotation) as GameObject;
        newUpgradedDef.transform.parent = defenderParent.transform;
    }
}
