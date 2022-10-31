using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseManager : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<XpManager>().UpdateProgress();
            Destroy(gameObject);
        }
    }
}
