﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private float speed = 50f;

    [SerializeField]
    private float damage = 20f;

    [SerializeField]
    private float lifetimeInSec = 2f;

    [SerializeField]
    private string shotBy;


    private float launchTime;

    private void Start()
    {
        launchTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - launchTime > lifetimeInSec)
        {
            Destroy(gameObject);
            return;
        }

        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != shotBy)
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<DestructibleObjectController>().TakesDamage(damage);
        }
    }

    private void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
