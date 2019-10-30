using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : DestructibleObjectController
{

    [SerializeField]
    protected float maxSpeed = 5f;

    [SerializeField]
    protected float turnSpeed = 20f;

    //private void Start()
    //{

    //}

    //private void Update()
    //{
    //    /* Called every frame.
    //     * Interval times vary.
    //     * Used for regular updates like:
    //     * Moving non-physics objects
    //     * Recieving Inputs */
    //}

    //private void FixedUpdate()
    //{
    //    /* Called every Physics step. 
    //     * Intervals are consistent
    //     * Use for adjusting physic (Rigidbody) objects. */
    //}

    protected void Turn(float direction)
    {
        float yaw = turnSpeed * Time.deltaTime * direction;
        transform.Rotate(0, yaw, 0);
    }

    protected void Thrust(float direction)
    {
        transform.position += transform.forward * maxSpeed * Time.deltaTime * direction;
    }


}
