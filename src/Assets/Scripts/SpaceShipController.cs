using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : DestructibleObjectController
{

    [SerializeField]
    private float maxSpeed = 5f;

    [SerializeField]
    private float turnSpeed = 20f;

    [SerializeField]
    private float acceleration = 2f;

    private float velocity = 0f;
    private Rigidbody rb;

    protected void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    //private void Update()
    //{
    //    /* Called every frame.
    //     * Interval times vary.
    //     * Used for regular updates like:
    //     * Moving non-physics objects
    //     * Recieving Inputs */
    //}

    protected void FixedUpdate()
    {
        /* Called every Physics step. 
         * Intervals are consistent
         * Use for adjusting physic (Rigidbody) objects. */
        UpdateRigidBody();
    }

    private void UpdateRigidBody()
    {
        rb.velocity = transform.forward.normalized * Mathf.Clamp(velocity, -maxSpeed, maxSpeed);
    }

    private void AccelerateTo(float destSpeed)
    {
        velocity = Mathf.MoveTowards(velocity, destSpeed, acceleration * Time.fixedDeltaTime);
    }

    protected void Turn(float direction)
    {
        float yaw = turnSpeed * Time.deltaTime * direction;
        transform.Rotate(0, yaw, 0);
    }

    protected void Thrust(float direction)
    {
        AccelerateTo(maxSpeed * direction);
    }
}
