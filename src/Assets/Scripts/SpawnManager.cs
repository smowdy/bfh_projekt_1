﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject asteroidPrefab;

    [SerializeField]
    GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //Spawn directly at Spawnpoint
        //Spawn(asteroidPrefab, "asteroid_spawnpoint");
        Spawn(enemyPrefab, "enemy_spawnpoint");

        //Spawn Cluster at Spawnpoint
        SpawnCluster(asteroidPrefab, "asteroid_spawnpoint", 3, 10, 20);

        //Spawn random inside Boundry
        SpawnRandom(enemyPrefab, 5, 10);
        SpawnRandom(asteroidPrefab, 3, 10);
    }

    int maxRange = 50;

    //Do not Spawn to many Objects in a small place because it will loop forever...
    public void SpawnRandom(GameObject gameObject, int amount, int safetyDistance)
    {
        int i = 0;
        while (i < amount)
        {
            Vector3 spawnPos = getSpawnPosition();
            if (IsValidSpawnPos(spawnPos, safetyDistance))
            {
                Spawn(gameObject, spawnPos);
                i++;
            }

        }
    }

    public void SpawnRandom(GameObject gameObject, Vector3 center, int amount, int safetyDistance, int maxRange)
    {
        int i = 0;
        while (i < amount)
        {
            Vector3 spawnPos = getSpawnPosition(center, maxRange);
            if (IsValidSpawnPos(spawnPos, safetyDistance))
            {
                Spawn(gameObject, spawnPos);
                i++;
            }

        }
    }

    public void Spawn(GameObject gameObject, Vector3 spawnPos)
    {
        Instantiate(gameObject, spawnPos, Quaternion.identity);
    }

    public void Spawn(GameObject gameObject, string tag)
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject spawnPoint in spawnPoints)
        {
            Vector3 spawnPos = spawnPoint.transform.position;
            Destroy(spawnPoint);
            Spawn(gameObject, spawnPos);
        }
    }

    public void SpawnCluster(GameObject gameObject, string tag, int amount, int safetyDistance, int maxRange)
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject spawnPoint in spawnPoints)
        {
            Vector3 spawnPos = spawnPoint.transform.position;
            Destroy(spawnPoint);
            SpawnRandom(gameObject, spawnPos, amount, safetyDistance, maxRange);
        }
    }

    private Vector3 getSpawnPosition()
    {
        return new Vector3(Random.Range(-maxRange, maxRange), 0, Random.Range(-maxRange, maxRange));
    }

    private Vector3 getSpawnPosition(Vector3 center, int maxRange)
    {
        return center + new Vector3(Random.Range(-maxRange, maxRange), 0, Random.Range(-maxRange, maxRange));
    }

    private bool IsValidSpawnPos(Vector3 spawnPos, int safetyDistance)
    {
        return IsNotInReachOf(spawnPos, "player", safetyDistance)
            && IsNotInReachOf(spawnPos, "goal", safetyDistance)
            && IsNotInReachOf(spawnPos, "enemy", safetyDistance)
            && IsNotInReachOf(spawnPos, "asteroid", safetyDistance);
    }

    private bool IsNotInReachOf(Vector3 spawnPos, string tag, int safetyDistance)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject gameObject in gameObjects)
        {
            if (Vector3.Distance(gameObject.transform.position, spawnPos) <= safetyDistance)
            {
                return false;
            }
        }
        return true;
    }
}