using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : SpaceShipController
{
    [SerializeField]
    private GameObject target;

    private EnemyState state;

    protected new void Start()
    {
        base.Start();
        state = new EnemyIdleState(gameObject);
        if(target == null)
        {
            target = GameObject.FindGameObjectsWithTag("player").FirstOrDefault();
        }
    }

    private void Update()
    {
        state = state.Action(target);
    }
}
