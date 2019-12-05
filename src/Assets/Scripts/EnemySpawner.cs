using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    int numberOfEnemies = 20;


    // Start is called before the first frame update
    void Awake()
    {
        for (int i=0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
        }
    }
}
