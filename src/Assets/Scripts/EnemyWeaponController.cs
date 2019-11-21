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
        if(Vector3.Distance(transform.position, target.position) <= 10)
        {
Aim((target.position - transform.position).normalized);
        TryShoot("enemy");
        }
        
    }
}
