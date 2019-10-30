using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private Transform[] projectileSpawns;

    [SerializeField]
    private float shotsPerSecond = 10f;

    [SerializeField]
    private float turnSpeed = 1f;

    private float nextShotAt = 0f;
    private int lastUsedProjectileSpawn = 0;
    private Vector3 lastAimedDirection = Vector3.zero;
    private float initialAimAngle = 0;

    protected void Aim(Vector3 direction)
    {
        lastAimedDirection = direction;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        //transform.rotation = targetRotation;
    }

    protected void TryShoot()
    {
        if (!CanShoot()) { return; }

        nextShotAt = Time.time + 1 / shotsPerSecond;

        Transform spawn = GetNextProjectileSpawn();
        Instantiate(projectilePrefab, spawn.transform.position, spawn.transform.rotation);
    }

    private bool CanShoot()
    {
        if (Time.time < nextShotAt) { return false; }
        return true;
    }

    private Transform GetNextProjectileSpawn()
    {
        int nextSpawnIndex = (lastUsedProjectileSpawn + 1) % projectileSpawns.Length;
        lastUsedProjectileSpawn = nextSpawnIndex;
        return projectileSpawns[nextSpawnIndex];
    }
}
