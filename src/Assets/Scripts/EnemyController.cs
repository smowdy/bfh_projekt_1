using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] float turnSpeed = 2f;
    float turnDirection = 1;

    private void Start()
    {
        InvokeRepeating("SetRandomDirection", 0.1f, 3.0f);
    }
    // Update is called once per frame
    void Update()
    {
        Turn();
        Thrust();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * turnDirection;

        transform.Rotate(0, yaw, 0);
    }
    void Thrust()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;

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
