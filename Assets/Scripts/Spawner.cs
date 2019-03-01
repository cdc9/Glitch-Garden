using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

    private GameObject AttackerParent;

    void Start()
    {
        AttackerParent = GameObject.Find("Attackers");

        //Creating a defender object to hold all newly spawned defenders. Keeps the heiarchy cleaner
        if (!AttackerParent)
        {
            AttackerParent = new GameObject("Attackers");
        }
    }

    // Update is called once per frame
    void Update () {

        foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (IsTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }    
	}

    bool IsTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if(Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by framerate");
        }

        float threshhold = spawnsPerSecond * Time.deltaTime / 5;

        return (Random.value < threshhold);
    }
    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject; 
        myAttacker.transform.parent = transform; 
        myAttacker.transform.position  = transform.position;
    }
}
