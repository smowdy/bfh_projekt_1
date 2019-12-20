using System.Linq;
using UnityEngine;

public class EnemyWeaponController : WeaponController
{
    [SerializeField]
    private float engageDistance = 20;

    [SerializeField]
    private Transform target = null;

    protected new void Start()
    {
        base.Start();
        if (target == null)
        {
            GameObject targetObject = GameObject.FindGameObjectsWithTag("player").FirstOrDefault();
            target = targetObject.transform;
        }
    }

    private void Update()
    {
        AimAndTryShoot();        
    }

    private void AimAndTryShoot()
    {
        if (Vector3.Distance(transform.position, target.position) <= engageDistance)
        {
            Aim((target.position - transform.position).normalized);
            TryShoot("enemy");
        }
    }

}
