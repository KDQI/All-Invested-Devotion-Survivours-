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
    private float startFireRate;
    private float fireRate;

    private void Awake()
    {
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
    }
}
