using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController1 : WeaponController
{
    // Update is called once per frame
    void Update()
    {
        TryShoot("enemy");
    }
}
