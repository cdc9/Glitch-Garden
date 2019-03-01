using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    void Start()
    {
        animator = GetComponent<Animator>();

        //Creates a parent if necessary
        projectileParent = GameObject.Find("Projectiles");

        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        //Set lane spawner
        SetMyLaneSpawner();
    }

    void Update()
    {
        if(IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    void SetMyLaneSpawner()
    {

        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach (Spawner spawner in spawnerArray)
        {
            if(spawner.transform.position.y == transform.position.y )
            {
                myLaneSpawner = spawner;
                return;
            }
        }

        Debug.LogError(name + "Can't find spawner in lane");
    }

    bool IsAttackerAheadInLane()
    {
        //Exit if there are no attackers in lane
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        //If there are attackers, are they ahead?
        foreach(Transform attacker in myLaneSpawner.transform)
        {
            if(attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        //Attacker is lane but behind us
        return false;
    }
    //This is a method you will be putting into the animator of the person shooting. It will spawn a bullet everytime the animator cycles through
    private void Fire()
    {
        //Create a bullet based on whatever "projectile" the gameObject has assigned
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        //Set the spawn location to the location of the parent
        newProjectile.transform.parent = projectileParent.transform;
        //Spawn the bullet in the parent's gun location
        newProjectile.transform.position = gun.transform.position;
    }
}
