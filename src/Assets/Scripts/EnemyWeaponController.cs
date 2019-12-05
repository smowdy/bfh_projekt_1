using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyWeaponController : WeaponController
{
    // Update is called once per frame

    private Transform target;

    protected new void Start()
    {
        if (target == null)
        {
            GameObject targetObject = GameObject.FindGameObjectsWithTag("player").FirstOrDefault();
            target = targetObject.transform;
        }
    }

    void Update()
    {
        AimAndTryShoot();        
    }

    private void AimAndTryShoot()
    {
        if (Vector3.Distance(transform.position, target.position) <= 10)
        {
            Aim((target.position - transform.position).normalized);
            TryShoot("enemy");
        }
    }

}
