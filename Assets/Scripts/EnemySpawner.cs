using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField]
    private int minRange, maxRange;

    [SerializeField]
    private float startSpawnCooldown, spawnAmountMultiplier;
    private float spawnCooldown;

    [SerializeField]
    private float[] spawnChances;

    [SerializeField]
    private GameObject[] enemyObjects;

    private int enemySpawnAmount;

    private void Awake()
    {
        enemySpawnAmount = (int)(5 * spawnAmountMultiplier);
        spawnCooldown = Time.time + startSpawnCooldown;
    }

    private void Update()
    {
        if(Time.time >= spawnCooldown)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        spawnCooldown = Time.time + startSpawnCooldown;
        for(int i = 0; i < enemySpawnAmount; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-minRange, maxRange), Random.Range(-minRange, maxRange));
            int chosenEnemy = Random.Range(0, 100);
            for(int k = 0; k < enemyObjects.Length; k++)
            {
                if(chosenEnemy <= spawnChances[k])
                {
                    SpawnObject(enemyObjects[k], pos);
                }
            }
        }

    }


}
