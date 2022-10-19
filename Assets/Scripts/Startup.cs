using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    [SerializeField]
    private GameObject startingWeapon;
    [SerializeField]
    private WeaponSlot firstWeaponSlot;

    private void Awake()
    {
        GameObject weaponToAdd = Instantiate(startingWeapon, firstWeaponSlot.transform.position, Quaternion.identity);
        firstWeaponSlot.setWeapon(weaponToAdd);
    }
}
