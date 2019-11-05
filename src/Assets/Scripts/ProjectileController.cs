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
        Destroy(gameObject);
        if(other.gameObject.name == "Enemy")
        {
             other.gameObject.GetComponent<EnemyController>().TakesDamage(20);
        }
    }

    private void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
