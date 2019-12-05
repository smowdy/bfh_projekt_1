using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : ObjectManager
{
    [SerializeField]
    GameObject asteroidPrefab;

    [SerializeField]
    GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Spawn(asteroidPrefab, "asteroid_spawnpoint");
        Spawn(enemyPrefab, "enemy_spawnpoint");
        SpawnRandom(enemyPrefab, 5, 10);
        SpawnRandom(asteroidPrefab, 5, 10);
    }
}
