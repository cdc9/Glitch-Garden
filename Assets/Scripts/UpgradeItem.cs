using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItem : MonoBehaviour {

    private Upgrade upgrade;
    private UpgradeDisplay upgradeDisplay;
    // Use this for initialization
    void Start () {
        upgrade = GameObject.FindObjectOfType<Upgrade>();
        upgradeDisplay = GameObject.FindObjectOfType<UpgradeDisplay>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown()
    {
        upgrade.upgradeCount++;
        upgradeDisplay.UpdateDisplay(upgrade.upgradeCount);
        Destroy(gameObject);
    }
}
