using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : WeaponController
{
    // Update is called once per frame

    [SerializeField]
    private Transform target;

    void Update()
    {
        if(!FindTarget())
        {
            return;
        }
        AimAndTryShoot();        
    }

    private void AimAndTryShoot()
    {
        if(Vector3.Distance(transform.position, target.position) <= 10)
        {
            Aim((target.position - transform.position).normalized);
            TryShoot("enemy");
        }
    }

    bool FindTarget()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("player").transform;
            return false;
        }
        return true;
    }
}
