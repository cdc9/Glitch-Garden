using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UpgradeDisplay : MonoBehaviour 
{

    public enum Status { SUCCESS, FAILURE };
    private int totalStars = 1000;

    private Text upgradeText;

    // Use this for initialization
    void Start()
    {
        upgradeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateDisplay(int upgradeCount)
    {
        upgradeText.text = upgradeCount.ToString();
    }
}
