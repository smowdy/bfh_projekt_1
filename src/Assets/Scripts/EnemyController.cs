using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SpaceShipController
{
    private float turnDirection = 1;

    protected new void Start()
    {
        base.Start();
        InvokeRepeating("SetRandomDirection", 0.1f, 3.0f);
    }

    private void Update()
    {
        Turn();
        Thrust();
    }

    private void Turn()
    {
        Turn(turnDirection);
    }

    private void Thrust()
    {
        Thrust(1);
    }

    private void SetRandomDirection()
    {
        if (Random.Range(-1, 1) >= 0)
        {
            turnDirection = 1;
        }
        else
        {
            turnDirection = -1;
        }
    }
}
