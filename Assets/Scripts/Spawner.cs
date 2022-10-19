using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void SpawnObject(GameObject objectToSpawn, Vector2 pos)
    {
        Instantiate(objectToSpawn, pos, Quaternion.identity);
    }
}
