using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
   [SerializeField] private GameObject projectilePrefab;
   [SerializeField] private GameObject[] projectileSpawns;
   [SerializeField] private float shotsPerSecond = 0.1f;
   [SerializeField] private float turnSpeed = 1f;

   private float nextShotAt = 0f;
   private int lastUsedProjectileSpawn = 0;

   private void Update()
   {
      Aim();
      Shoot();
   }

   private void Aim()
   {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      Plane plane = new Plane(transform.up, transform.position);
      float distance;
      if (plane.Raycast(ray, out distance))
      {
         Vector3 targetPosition = ray.GetPoint(distance);
         Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
         transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
         //transform.rotation = targetRotation;
      }
   }

   private void Shoot()
   {
      if (!(Input.GetAxis("Fire1") > 0) ||
         Time.time < nextShotAt)
      {
         return;
      }

      nextShotAt = Time.time + shotsPerSecond;

      GameObject spawn = GetNextProjectileSpawn(lastUsedProjectileSpawn);
      Instantiate(projectilePrefab, spawn.transform.position, spawn.transform.rotation);
   }

   private GameObject GetNextProjectileSpawn(int lastUsedProjectileSpawn)
   {
      int nextShipBayToSpawnFrom = (lastUsedProjectileSpawn + 1) % projectileSpawns.Length;
      return projectileSpawns[nextShipBayToSpawnFrom];
   }
}
