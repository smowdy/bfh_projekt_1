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

    private string shotBy;

    public void SetShotBy(string shotBy)
    {
        this.shotBy = shotBy;
    }


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
        Debug.Log("entered collider " + other.name + " " + other.tag);
        if (other.gameObject.tag != shotBy)
        {
            var destructible = other.gameObject.GetComponent<DestructibleObjectController>();
            if(destructible != null)
            {
                Destroy(gameObject);
                destructible.TakesDamage(damage);
            }
        }
    }

    private void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
