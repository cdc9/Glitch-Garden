using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 100f;
    private Upgrade upgrade;

    void Start()
    {
        upgrade = GameObject.FindObjectOfType<Upgrade>();
    }

        public void DealDamage (float damage)
    {
        health -= damage;
        //If the target runs out of health, destroy it
        if(health <= 0)
        {
            //Optionally we could use a destroy animation here. In the same way we call setSpeed and StrikeCurrentTarget in the animator
            DestroyObject();
        }
    }

    //This is a method for destroying the game object
    public void DestroyObject()
    {
        //gameObject in this case is the entire object health is attached to. Not just Health.
        if (gameObject.GetComponent<Attacker>())
        {
            upgrade.AddToKillCount();
            upgrade.checkIfUpgradeCanBeDropped(gameObject.transform.position);
        }
        Destroy(gameObject);
    }
}
