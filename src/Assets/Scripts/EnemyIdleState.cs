using System.Timers;
using UnityEngine;

public class EnemyIdleState : EnemyState
{

    private float turnDirection = 1;
    private float nextDirectionUpdateAt = 0;
    private float detectionDistance = 10f;
    private float rayCastOffset = 3.5f;


    public EnemyIdleState(GameObject enemy, float engageDistance) : base(enemy, engageDistance) {
        SetRandomDirection();
    }

    public override EnemyState Action(GameObject target)
    {
        if((target.transform.position - enemy.transform.position).magnitude < engageDistance)
        {
            return new EnemyEngageState(enemy, engageDistance);
        }
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;
        Vector3 left = enemy.transform.position - enemy.transform.right * rayCastOffset;
        Vector3 right = enemy.transform.position + enemy.transform.right * rayCastOffset;

        Debug.DrawRay(left, enemy.transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(right, enemy.transform.forward * detectionDistance, Color.cyan);

        if(Physics.Raycast(left, enemy.transform.forward, out hit, detectionDistance))
        {
            raycastOffset += Vector3.right;
        }else if(Physics.Raycast(right, enemy.transform.forward, out hit, detectionDistance))
        {
            raycastOffset -= Vector3.right;
        }

        if (Time.time >= nextDirectionUpdateAt)
        {
            SetRandomDirection();
        }

        if(raycastOffset == Vector3.left)
        {
            //enemy.transform.Rotate(raycastOffset * 50f * Time.deltaTime);
            enemy.GetComponent<EnemyController>().Turn(-1);
        }
        else if (raycastOffset == Vector3.right) 
        {
            enemy.GetComponent<EnemyController>().Turn(1);
        }
        else
        {
            enemy.GetComponent<EnemyController>().Turn(turnDirection);
        }

        enemy.GetComponent<EnemyController>().Thrust(1);
        return this;
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

        nextDirectionUpdateAt = Time.time + 3;
    }
}
