﻿using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidPrefab = null;

    [SerializeField]
    private GameObject enemyPrefab = null;

    [SerializeField]
    private string enemySpawnPointTag = "enemy_spawnpoint";

    [SerializeField]
    private string asteroidSpawnPointTag = "asteroid_spawnpoint";

    [SerializeField]
    private string enemyClusterPointTag = "enemy_clusterpoint";

    [SerializeField]
    private int enemyAmountPerCluster = 3;

    [SerializeField]
    private int enemySafeDistancePerCluster = 10;

    [SerializeField]
    private int enemyMaxRangePerCluster = 20;

    [SerializeField]
    private string asteroidClusterPointTag = "asteroid_clusterpoint";

    [SerializeField]
    private int asteroidAmountPerCluster = 3;

    [SerializeField]
    private int asteroidSafeDistancePerCluster = 10;

    [SerializeField]
    private int asteroidMaxRangePerCluster = 20;

    [SerializeField]
    private int enemyAmmountSpawnedArroundCenter = 5;

    [SerializeField]
    private int asteroidAmmountSpawnedArroundCenter = 5;

    [SerializeField]
    private int maxDistToSpawnRandomArroundCenter = 50;



    private void Start()
    {
        //Spawn directly at Spawnpoint
        Spawn(asteroidPrefab, asteroidSpawnPointTag);
        Spawn(enemyPrefab, enemySpawnPointTag);

        //Spawn Cluster at Spawnpoint
        SpawnCluster(enemyPrefab, enemyClusterPointTag, enemyAmountPerCluster, enemySafeDistancePerCluster, enemyMaxRangePerCluster);
        SpawnCluster(asteroidPrefab, asteroidClusterPointTag, asteroidAmountPerCluster, asteroidSafeDistancePerCluster, asteroidMaxRangePerCluster);

        //Spawn random inside Boundry
        SpawnRandom(enemyPrefab, enemyAmmountSpawnedArroundCenter, enemySafeDistancePerCluster, maxDistToSpawnRandomArroundCenter);
        SpawnRandom(asteroidPrefab, asteroidAmmountSpawnedArroundCenter, asteroidSafeDistancePerCluster, maxDistToSpawnRandomArroundCenter);
    }

    //Do not Spawn too many Objects in a small place because it will loop forever...
    public void SpawnRandom(GameObject gameObject, int amount, int safetyDistance, int maxRange)
    {
        int i = 0;
        while (i < amount)
        {
            Vector3 spawnPos = getSpawnPosition(maxRange);
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
        if(gameObject == null) { return; }
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

    private Vector3 getSpawnPosition(int maxRange)
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
