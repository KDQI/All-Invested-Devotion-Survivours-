using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private WeaponSlot[] weaponSlots;
    public static PlayerShoot instance;

    private void Awake()
    {
        instance = this;
    }

    public void addWeaponToSlot(int slot, GameObject weapon)
    {
        weaponSlots[slot].setWeapon(weapon);
    }

    public void addWeapon(GameObject weapon)
    {
        for(int i = 0; i < weaponSlots.Length; i++)
        {
            if(weaponSlots[i].isInUse() == false)
            {
                weaponSlots[i].setWeapon(weapon);
                break;
            }else if(i == weaponSlots.Length-1)
            {
                Debug.LogError("PlayerShoot.addWeapon() - All weapon slots full!");
            }
        }
    }

    public bool allSlotsFull()
    {
        bool result = true;
        for(int i = 0; i < weaponSlots.Length; i++)
        {
            if(weaponSlots[i].isInUse() == false)
            {
                result = false;
                break;
            }
        }
        return result;
    }
}

