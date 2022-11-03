using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpScript : MonoBehaviour
{

    [SerializeField]
    private GameObject levelUpCanvas;
    public static LevelUpScript levelup;

    public int extraDmg;
    public float fireRate = 0.75f;

    private void Start()
    {
        levelup = this;
    }

    public void LevelUp()
    {
        levelUpCanvas.SetActive(true);
        Time.timeScale = 0;

    }

    public void AttackSpeed()
    {
        levelUpCanvas.SetActive(false);
        Time.timeScale = 1;
        fireRate -= 0.10f;
    }

    public void MoreHp()
    {
        levelUpCanvas.SetActive(false);
        Time.timeScale = 1;
        PlayerHealth.ph.playerMaxHp += 5;
    }

    public void MoreDamage()
    {
        levelUpCanvas.SetActive(false);
        Time.timeScale = 1;
        extraDmg += 1;
    }

    public void Speed()
    {
        levelUpCanvas.SetActive(false);
        Time.timeScale = 1;
        PlayerMovement.instance.speed += 0.5f;
    }

    public void Regen()
    {
        levelUpCanvas.SetActive(false);
        Time.timeScale = 1;
        PlayerHealth.ph.playerHp = PlayerHealth.ph.playerMaxHp;
    }
}
