using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{

    private void Start()
    {
        WeaponManager.instance.addWeapon(0);
    }

}
