using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject graphics;
    private Animator anim;

    
    private float fireRate;


    public static Weapon wpn;
    private void Awake()
    {
        wpn = this;
        anim = graphics.GetComponent<Animator>();
        fireRate = LevelUpScript.levelup.fireRate;
    }

    public void Update()
    {
        fireRate -= Time.deltaTime;
        if (fireRate <= 0)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.transform.rotation);
        fireRate = LevelUpScript.levelup.fireRate;
        anim.speed = 1.2f / fireRate;
        anim.SetTrigger("Reload");
    }
}
