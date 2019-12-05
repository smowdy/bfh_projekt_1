using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : ObjectManager
{
    [SerializeField]
    GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnRandom(enemyPrefab, 10, 10);
    }
}
