using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    public static ItemSpawner instance;
    [SerializeField]
    private GameObject[] items;
    private void Awake()
    {
        instance = this;
    }
    public void SpawnItem(int id, Vector3 pos)
    {
        SpawnObject(items[id], pos);
    }

}
