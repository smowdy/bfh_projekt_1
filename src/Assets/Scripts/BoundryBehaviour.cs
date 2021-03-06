﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoundryBehaviour : MonoBehaviour
{
    [SerializeField]
    float damagePerGameTick = 1;

    private List<DestructibleObjectController> objectsOutsideBoundry = new List<DestructibleObjectController>();

    private void FixedUpdate()
    {
        DamageObjectsOutsideBoundry();
    }

    private void DamageObjectsOutsideBoundry()
    {
        foreach (var removable in objectsOutsideBoundry.Where(x => x == null).ToArray())
        {
            objectsOutsideBoundry.Remove(removable);
        }

        foreach (var destructible in objectsOutsideBoundry)
        {
            destructible.TakesDamage(damagePerGameTick);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var destructible = other.gameObject.GetComponent<DestructibleObjectController>();
        if (destructible == null) { return; }

        objectsOutsideBoundry.Remove(destructible);
    }

    private void OnTriggerExit(Collider other)
    {
        var destructible = other.gameObject.GetComponent<DestructibleObjectController>();
        if(destructible == null) { return; }

        if (objectsOutsideBoundry.Any(x => x.Equals(destructible))) { return; }
        objectsOutsideBoundry.Add(destructible);
    }
}
