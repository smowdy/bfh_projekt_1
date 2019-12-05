﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    int numberOfEnemies = 20;

    int safetyDistance = 30;

    public void SpawnEnemies(GameObject enemyPrefab)
    {
        int i = 0;
        while (i < numberOfEnemies)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
            if (IsValidSpawnPos(spawnPos))
            {
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                i++;
            }
            
        }
    }

    private bool IsValidSpawnPos(Vector3 spawnPos)
    {
        return IsNotInReachOf(spawnPos, "player") || IsNotInReachOf(spawnPos, "goal");
    }

    private bool IsNotInReachOf(Vector3 spawnPos, string tag)
    {
        GameObject target = GameObject.FindGameObjectsWithTag(tag).FirstOrDefault();
        return Vector3.Distance(target.transform.position, spawnPos) >= safetyDistance;
    }
}
