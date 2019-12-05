using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitalizer : MonoBehaviour
{

    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameObject asteroidPrefab;

    EnemySpawner enemySpawner = new EnemySpawner();

    AsteroidManager asteroidManager = new AsteroidManager();

    void Awake()
    {
        enemySpawner.SpawnEnemies(enemyPrefab);
        asteroidManager.Spawn(asteroidPrefab, 20, 30);
    }
}
