using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    private Text textPlayerHp;

    public int playerHp;
    public int playerMaxHp = 10;

    public static PlayerHealth ph;


    private void Awake()
    {
        ph = this;
        playerHp = playerMaxHp;
    }
    void Update()
    {
        textPlayerHp.text = playerHp.ToString() + " / " + playerMaxHp;
        
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
