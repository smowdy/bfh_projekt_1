using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoundryBehaviour : MonoBehaviour
{
    private List<DestructibleObjectController> objectsOutsideBoundry = new List<DestructibleObjectController>();

    private void FixedUpdate()
    {
        DamageObjectsOutsideBoundry();
    }

    private void DamageObjectsOutsideBoundry()
    {
        foreach (var destructible in objectsOutsideBoundry)
        {
            destructible.TakesDamage(1);
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
        if(destructible == null)
        {
            Destroy(other.gameObject);
            return;
            
        }

        if (objectsOutsideBoundry.Any(x => x.Equals(destructible))) { return; }
        objectsOutsideBoundry.Add(destructible);
    }
}
