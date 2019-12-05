using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class AsteroidManager : MonoBehaviour
{
    public void Spawn(GameObject enemyPrefab, int amount, int safetyDistance)
    {
        int i = 0;
        while (i < amount)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
            if (IsValidSpawnPos(spawnPos, safetyDistance))
            {
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                i++;
            }

        }
    }

    private bool IsValidSpawnPos(Vector3 spawnPos, int safetyDistance)
    {
        return IsNotInReachOf(spawnPos, "player", safetyDistance) || IsNotInReachOf(spawnPos, "goal", safetyDistance);
    }

    private bool IsNotInReachOf(Vector3 spawnPos, string tag, int safetyDistance)
    {
        GameObject target = GameObject.FindGameObjectsWithTag(tag).FirstOrDefault();
        return Vector3.Distance(target.transform.position, spawnPos) >= safetyDistance;
    }
}
