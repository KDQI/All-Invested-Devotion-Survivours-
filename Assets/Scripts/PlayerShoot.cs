using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private float startFireRate;
    private float fireRate;
    private bool fireRateBool;


    private void Start()
    {

    }

    private void Update()
    {
        ProsessInputs();
        CheckFireRate();
    }

    private void ProsessInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (fireRate <= 0)
            {
                Fire();
            }
        }
    }
    private void CheckFireRate()
    {
        if (fireRateBool == true)
        {
            fireRate -= Time.deltaTime;

            if (fireRate <= 0)
            {
                fireRateBool = false;
            }
        }

    }
    private void Fire()
    {
        fireRate = startFireRate;
        fireRateBool = true;
        Instantiate(bullet, firePoint.position, firePoint.rotation);

    }
}

