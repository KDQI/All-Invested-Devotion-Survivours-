using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : Seek
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private float attackRange, attackCooldown, speedForAttack, damageRange, slowTime, slowedSpeed;
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
        if(this.transform.position.x > GetTarget().transform.position.x)
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
        if (Vector3.Distance(this.transform.position, GetTarget().transform.position) <= attackRange)
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
        if (Vector3.Distance(this.transform.position, GetTarget().transform.position) <= damageRange)
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
        SetSpeed(speedForAttack);
        yield return new WaitForSeconds(attackCooldown);
        if (inDamageRange())
        {
            Debug.Log("Enemy did damage");
            GetTarget().GetComponent<PlayerHealth>().damagePlayer(1);
            StartCoroutine(SlowForTime());
        }
        ResetSpeed();
        attacking = false;
    }

    IEnumerator SlowForTime()
    {
        SetSpeed(slowedSpeed);
        yield return new WaitForSeconds(slowTime);
        ResetSpeed();
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        Debug.Log("Enemy took damage " + hp + " hp remaining");
        StartCoroutine(SlowForTime());
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
            Debug.Log("Enemy Died");
            Destroy(gameObject);
            ItemSpawner.instance.SpawnItem(0, this.transform.position);
        }
    }
}
