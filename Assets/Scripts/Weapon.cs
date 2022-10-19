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

    [SerializeField]
    private float startFireRate;
    private float fireRate;

    private void Awake()
    {
        anim = graphics.GetComponent<Animator>();
        fireRate = startFireRate;
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
        fireRate = startFireRate;
        anim.speed = 1.2f / fireRate;
        anim.SetTrigger("Reload");
    }
}
