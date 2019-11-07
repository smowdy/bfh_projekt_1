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
    private Transform parentTransform;

    [SerializeField]
    private float shotsPerSecond = 10f;

    [SerializeField]
    private float turnDegreePerSecond = 360f;

    [SerializeField]
    [Range(0, 360)]
    private float maxTurnDegree = 360f;

    [SerializeField]
    [Range(0, 360)]
    private float maxAngleDeltaToShoot = 5f;

    private float nextShotAt = 0f;
    private int lastUsedProjectileSpawn = 0;
    private Vector3 lastAimedDirection = Vector3.zero;
    private Quaternion initialRotation = Quaternion.identity;

    private void Start()
    {
        initialRotation = transform.localRotation;
    }

    protected void Aim(Vector3 direction)
    {
        lastAimedDirection = direction;

        if (maxTurnDegree == 0) { return; }

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        if(maxTurnDegree == 360)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnDegreePerSecond * Time.deltaTime);
            return;
        }

        targetRotation = GetLimitedRotation(targetRotation);
        if(Quaternion.Angle(transform.rotation, GetInitialRelativeRotation()) + Quaternion.Angle(transform.rotation, targetRotation) > 180)
        {
            targetRotation = GetInitialRelativeRotation();
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnDegreePerSecond * Time.deltaTime);

    }

    protected void TryShoot(string shotBy)
    {
        if (!CanShoot()) { return; }

        nextShotAt = Time.time + 1 / shotsPerSecond;
        Transform spawn = GetNextProjectileSpawn();
        GameObject projectile = Instantiate(projectilePrefab, spawn.transform.position, spawn.transform.rotation);
        projectile.GetComponent<ProjectileController>().SetShotBy(shotBy);
    }

    private Quaternion GetLimitedRotation(Quaternion targetRotation)
    {
        return Quaternion.RotateTowards(GetInitialRelativeRotation(), targetRotation, maxTurnDegree / 2);
    }

    /// <summary>
    /// Returns a Quaternion representing the initial rotation relative to woldspace
    /// </summary>
    /// <returns>Quaternion</returns>
    private Quaternion GetInitialRelativeRotation()
    {
        return Quaternion.Euler(
            parentTransform.rotation.eulerAngles.x + initialRotation.eulerAngles.x,
            parentTransform.rotation.eulerAngles.y + initialRotation.eulerAngles.y,
            parentTransform.rotation.eulerAngles.z + initialRotation.eulerAngles.z
        );
    }

    private bool CanShoot()
    {
        if (Time.time < nextShotAt) { return false; }
        float angleDelta = Vector3.Angle(lastAimedDirection, transform.forward);
        return angleDelta <= maxAngleDeltaToShoot;
    }

    private Transform GetNextProjectileSpawn()
    {
        int nextSpawnIndex = (lastUsedProjectileSpawn + 1) % projectileSpawns.Length;
        lastUsedProjectileSpawn = nextSpawnIndex;
        return projectileSpawns[nextSpawnIndex];
    }
}
