using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Spawner
{
    public static ObjectSpawner instance;
    [SerializeField]
    private GameObject[] items, particles;
    private void Awake()
    {
        instance = this;
    }
    public void SpawnItem(int id, Vector3 pos)
    {
        SpawnObject(items[id], pos);
    }

    public void SpawnParticle(int id, Vector3 pos)
    {
        SpawnObject(particles[id], pos);
    }

}
