using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyObject;
    [SerializeField] float spawnTimer = 5f;

    private void Start()
    {
        StartSpawning();
    }

    void SpawnEnemy()
    {
        Instantiate(enemyObject, transform.position, Quaternion.identity);
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
    }

    void StopSpawning()
    {
        CancelInvoke();
    }
}
