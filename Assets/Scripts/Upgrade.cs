using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour {

    public int enemyKillCount;
    public GameObject upgradeDropItem;
    public int upgradeCount;
    public bool isUpgradeSelected;

    private GameObject upgradeParent;
    private UpgradeDisplay upgradeDisplay;

    // Use this for initialization
    void Start () {
        enemyKillCount = 0;

        //Creates a parent if necessary
        upgradeParent = GameObject.Find("Upgrades");

        if (!upgradeParent)
        {
            upgradeParent = new GameObject("Upgrades");
        }

        upgradeDisplay = GameObject.FindObjectOfType<UpgradeDisplay>();

        upgradeDisplay.UpdateDisplay(upgradeCount);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            DeselectUpgradeIcon();
        }
    }

    //Increase the kill count when an enemy dies
    public void AddToKillCount()
    {
        enemyKillCount++;
    }

    public void DropUpgrade()
    {
        //Create an upgrade drop after the required kill count has been met
        GameObject newUpgradeDropItem = Instantiate(upgradeDropItem) as GameObject;
        //Set the spawn location to the location of the parent
        newUpgradeDropItem.transform.parent = upgradeParent.transform;
    }

    public void SelectUpgradeIcon()
    {
        isUpgradeSelected = true;
    }

    public void DeselectUpgradeIcon()
    {
        isUpgradeSelected = false;
    }


    //This is for upgrading the tower. Spawn upgraded defender, subtract 1 from upgrade token amount, update display, and deselect upgrade icon
    public void UpgradeTower(Vector2 upgradedTowersPosition, GameObject upgradedDefender)
    {
        if (isUpgradeSelected && upgradeCount >= 1)
        {
            SpawnDefender(upgradedTowersPosition, upgradedDefender);
            upgradeCount--;
            upgradeDisplay.UpdateDisplay(upgradeCount);
            DeselectUpgradeIcon();
        }
        else
        {
            Debug.Log("Couldn't summon upgraded tower");
        }
    }


    public void OnMouseDown()
    {
        SelectUpgradeIcon();
    }

    public void checkIfUpgradeCanBeDropped(Vector3 enemyPosition)
    {
        if(enemyKillCount >= 3)
        {
            enemyKillCount = 0;
            //Create a bullet based on whatever "projectile" the gameObject has assigned
            GameObject upgradeItem = Instantiate(upgradeDropItem) as GameObject;
            //Spawn the bullet in the parent's location
            upgradeItem.transform.position = enemyPosition;
        }

    }

    //Spawn new defender in the old one's place
    void SpawnDefender(Vector2 upgradedTowersPosition, GameObject upgradedDefender)
    {
        Quaternion zeroRotation = Quaternion.identity; //Set rotation to zero
        GameObject newUpgradedDef = Instantiate(upgradedDefender, upgradedTowersPosition, zeroRotation) as GameObject;
    }

}
