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
    private Transform partenTransform;

    [SerializeField]
    private float shotsPerSecond = 10f;

    [SerializeField]
    private float turnSpeed = 1f;

    [SerializeField]
    [Range(0, 360)]
    private float maxTurnAngle = 360f;

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

        if (maxTurnAngle == 0) { return; }

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Vector3 targetRotationVector = targetRotation.eulerAngles;

        if (maxTurnAngle != 360)
        {
            targetRotation = GetLimitedRotation(targetRotation);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    protected void TryShoot()
    {
        if (!CanShoot()) { return; }

        nextShotAt = Time.time + 1 / shotsPerSecond;

        Transform spawn = GetNextProjectileSpawn();
        Instantiate(projectilePrefab, spawn.transform.position, spawn.transform.rotation);
    }

    private Quaternion GetLimitedRotation(Quaternion targetRotation)
    {
        Quaternion initialRelativeRotation = Quaternion.Euler(
            partenTransform.rotation.eulerAngles.x + initialRotation.eulerAngles.x,
            partenTransform.rotation.eulerAngles.y + initialRotation.eulerAngles.y,
            partenTransform.rotation.eulerAngles.z + initialRotation.eulerAngles.z
        );
        return Quaternion.RotateTowards(initialRelativeRotation, targetRotation, maxTurnAngle / 2);
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
