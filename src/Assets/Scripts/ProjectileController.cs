using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private float speed = 50f;

    [SerializeField]
    private float damage = 10f;

    [SerializeField]
    private float lifetimeInSec = 2f;


    private float _launchTime;

    private void Start()
    {
        _launchTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - _launchTime > lifetimeInSec)
        {
            Destroy(gameObject);
            return;
        }

        Move();
    }

    private void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
