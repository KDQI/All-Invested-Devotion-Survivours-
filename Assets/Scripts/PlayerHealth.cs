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

    public void damagePlayer(int dmg)
    {
        playerHp -= dmg;
        CheckIfDead();
    }

    void CheckIfDead()
    {
        if(playerHp <= 0)
        {
            Debug.Log("Player Dead");
        }
    }



}
