using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItem : MonoBehaviour {

    private Upgrade upgrade;
    private UpgradeDisplay upgradeDisplay;
    private bool hasBeenClicked;
    private Vector3 upgradesPosition;
    private int speed = 10;
    // Use this for initialization
    void Start () {
        upgrade = GameObject.FindObjectOfType<Upgrade>();
        upgradeDisplay = GameObject.FindObjectOfType<UpgradeDisplay>();
        hasBeenClicked = false;
        upgradesPosition = upgrade.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if(hasBeenClicked == true)
        {
            // Move our position a step closer to the target.
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, upgradesPosition, step);
        }
        if (Vector3.Distance(transform.position, upgradesPosition) < 0.001f)
        {
            upgrade.upgradeCount++;
            upgradeDisplay.UpdateDisplay(upgrade.upgradeCount);
            Destroy(gameObject);
        }
        
    }

    public void OnMouseDown()
    {
        //Add an upgrade token to your pool and update the number on screens
        //upgrade.upgradeCount++;
        //upgradeDisplay.UpdateDisplay(upgrade.upgradeCount);
        hasBeenClicked = true;
        
    }
}
