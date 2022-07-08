using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range (0f, 5f)] float currentSpeed = 1f;
	GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
        else {return;}
    }
    
	void Update () {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        updateAnimationState();
    }

    public void SetMovementSpeed (float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;

    }

    public void strikeCurrentTarget(float damage)
    {
        if (!currentTarget) {return;}
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DamageDealer(damage);
        }
    }

    private void updateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);

        }
    }

}