using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip("Average number of seconds between appearances")]
    public float seenEverySeconds;
    public Animator anim;

    private float currentSpeed;
    private GameObject currentTarget;
    

	// Use this for initialization
	void Start () {
        //Grab the animator for your objects animation
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //Move the attacking units
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        //Allow the attacker to start attacking, assuming they are touching a defender
        if(!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }
}

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(name + " trigger enter");
    }

    //Deal damage to the target. Called from the animator at the time of the actual blow
    public void StrikeCurrentTarget(float damage)
    {
        if(currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if(health)
            {
                health.DealDamage(damage);
            }
        }
       
    }
    

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
