using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weapons;

    public static WeaponManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void addWeapon(int id)
    {
        if(!PlayerShoot.instance.allSlotsFull())
        {
            GameObject weaponToAdd = Instantiate(weapons[id], this.transform.position, Quaternion.identity);
            PlayerShoot.instance.addWeapon(weaponToAdd);
        }
    }
}
