using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed, damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Move the projectile
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    //If the gameObject moves off camera, destroy it. However, since the spriterenderer is on the body not the parent object, this won't work for this project
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        Health health = collision.gameObject.GetComponent<Health>();

        if (health && attacker)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        
        
    }
}
