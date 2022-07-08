using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]  GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";


    private void Start()
    {
        setLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();

    }
    private void Update()
    {
        if (isAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);

        }
    }

    private void CreateProjectileParent()
    {
         projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent) 
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }


    }


    private void setLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool isAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else 
        {
            return true;
        }
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate (projectile, gun.transform.position, gun.transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
