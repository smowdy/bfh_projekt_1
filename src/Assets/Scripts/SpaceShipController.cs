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

    protected void OnTriggerStay(Collider other)
    {
        var destructible = other.gameObject.GetComponent<DestructibleObjectController>();
        if (destructible == null) { return; }

        ResetVelocityOnCollision(other.transform);
    }

    private void UpdateRigidBody()
    {
        rb.velocity = transform.forward.normalized * Mathf.Clamp(velocity, -maxSpeed, maxSpeed);
    }

    private void AccelerateTo(float destSpeed)
    {
        velocity = Mathf.MoveTowards(velocity, destSpeed, acceleration * Time.deltaTime);
    }

    public void Turn(float direction)
    {
        float yaw = turnSpeed * Time.deltaTime * direction;
        transform.Rotate(0, yaw, 0);
    }

    public void Turn(Vector3 direction)
    {
        float sAngle = Vector3.SignedAngle(transform.forward, direction, transform.up);
        Turn(sAngle < 0 ? -1 : 1);
    }

    public void Thrust(float direction)
    {
        AccelerateTo(maxSpeed * direction);
    }

    protected void ResetVelocityOnCollision(Transform other)
    {
        Vector3 collisionDirection = (other.position - transform.position).normalized;
        if (Vector3.Angle(collisionDirection, transform.forward) < 20 ||
           Vector3.Angle(collisionDirection, -transform.forward) < 20)
        {
            //resets when collision angle is in 40° cone forward or backwards
            velocity = 0;
        }
    }
}
