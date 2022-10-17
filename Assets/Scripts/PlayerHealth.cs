using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    private Text textPlayerHp;

    private int playerHp = 10;

    void Update()
    {
        textPlayerHp.text = playerHp.ToString() + " / 10";
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            playerHp--;
            CheckIfDead();
        }
                   
    }

    void CheckIfDead()
    {
        if(playerHp <= 0)
        {
            Debug.Log("Player Dead");
        }
    }



}
