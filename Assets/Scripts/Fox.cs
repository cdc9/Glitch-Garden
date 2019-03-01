using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>(); 
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        //Leave the method if not colliding with a defender
        if(!obj.GetComponent<Defender>())
        {
            return;
        }

        //If the fox comes into contact with a gravestone, trigger animator to make the fox jump.
        if (obj.GetComponent<Stone>())
        {
            anim.SetTrigger("jumpTrigger");
            Debug.Log("You touched a gravestone fox!");
        }

        //If the fox collides with anything else, attack it
        else
        {
            anim.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
        Debug.Log("Fox collided with " + collision);
    }
}
