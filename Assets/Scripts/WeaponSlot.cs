using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    private GameObject weapon;
    [SerializeField]
    private Transform targetPos;
    [SerializeField]
    private float rotationOffset, locationOffset, distanceFromCenter;
    [SerializeField]
    private bool inUse = false;

    private void Awake()
    {
        inUse = false;
    }
    private void Update()
    {
        if(inUse)
        {
            Vector3 tPos = Camera.main.WorldToScreenPoint(targetPos.position);
            tPos = Input.mousePosition - tPos;
            float angle = (Mathf.Atan2(tPos.y, tPos.x) * Mathf.Rad2Deg) + locationOffset;
            weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));
            tPos = Quaternion.AngleAxis(angle, Vector3.forward) * (Vector3.right * distanceFromCenter);
            transform.position = targetPos.position + tPos;
            weapon.transform.position = this.transform.position;
        }
    }

    public bool isInUse()
    {
        if (inUse)
            return true;
        else
            return false;
    }

    public void setWeapon(GameObject g)
    {
        Debug.Log("Adding weapon");
        if(!inUse)
        {
            weapon = g;
            inUse = true;
        }
    }

    public Weapon getWeapon()
    {
        return weapon.gameObject.GetComponent<Weapon>();
    }
}
