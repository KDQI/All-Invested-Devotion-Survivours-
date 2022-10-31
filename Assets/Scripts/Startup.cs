using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{

    private void Start()
    {
        for(int i = 0; i < 8; i++)
        {
            WeaponManager.instance.addWeapon(0);
        }
    }

}
