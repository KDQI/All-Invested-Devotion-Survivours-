using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : Seek
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private float attackRange, attackCooldown, speedForAttack, damageRange;
    [SerializeField]
    private Animator anim;
    private bool attacking;
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private GameObject damageText;
    [SerializeField]
    private TextMesh takenDamageTxt;
    [SerializeField]
    private GameObject coin;


    private void Start()
    {
       
    }

    public void Update()
    {
        Flip();
        if (inAttackRange())
        {
            attack();
        }
    }
    
    public void Flip()
    {
        if(this.transform.position.x > getTarget().transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        
    }
    private bool inAttackRange()
    {
        if (Vector3.Distance(this.transform.position, getTarget().transform.position) <= attackRange)
        {
            return true;
        }
        else
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
        if (!attacking)
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
            Debug.Log("Enemy did damage");
            getTarget().GetComponent<PlayerHealth>().damagePlayer(1);
        }
        resetSpeed();
        attacking = false;
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        Debug.Log("Enemy took damage " + hp + " hp remaining");
        StartCoroutine(ShowTakenDamage(dmg));
        CheckIfEnemyDead();
    }

    private IEnumerator ShowTakenDamage(int dmg)
    {
        takenDamageTxt.text = dmg.ToString();
        damageText.SetActive(true);       
        yield return new WaitForSeconds(1);
        damageText.SetActive(false);
    }

    private void CheckIfEnemyDead()
    {
        if (hp <= 0)
        {
            Debug.Log("Enemý Died");
            Destroy(gameObject);
        }
    }
}
