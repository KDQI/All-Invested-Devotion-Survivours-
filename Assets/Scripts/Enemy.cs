using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Seek
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private float attackRange, attackCooldown, speedForAttack, damageRange;
    [SerializeField]
    private Animator anim;
    private bool attacking;

    public void Update()
    {
        if(inAttackRange())
        {
            attack();
        }
    }

    private bool inAttackRange()
    {
        if(Vector3.Distance(this.transform.position, getTarget().transform.position) <= attackRange)
        {
            return true;
        }else
        {
            return false;
        }
    }

    private bool inDamageRange()
    {
        if (Vector3.Distance(this.transform.position, getTarget().transform.position) <= damageRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void attack()
    {
        if(!attacking)
        {
            StartCoroutine(waitForAttack());
        }
    }

    IEnumerator waitForAttack()
    {
        attacking = true;
        anim.SetTrigger("Attacking");
        setSpeed(speedForAttack);
        yield return new WaitForSeconds(attackCooldown);
        if (inDamageRange())
        {
            Debug.Log("did damage");
            getTarget().GetComponent<PlayerHealth>().damagePlayer(1);
        }
        resetSpeed();
        attacking = false;
    }
}
