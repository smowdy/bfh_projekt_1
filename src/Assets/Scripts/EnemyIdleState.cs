using System.Timers;
using UnityEngine;

public class EnemyIdleState : EnemyState
{

    private float turnDirection = 1;
    private float nextDirectionUpdateAt = 0;
    private float detectionDistance = 10f;
    private float rayCastWidth = 3.5f;

    public EnemyIdleState(GameObject enemy, float engageDistance) : base(enemy, engageDistance) {
        SetRandomDirection();
    }

    public override EnemyState Action(GameObject target)
    {
        if((target.transform.position - enemy.transform.position).magnitude < engageDistance)
        {
            return new EnemyEngageState(enemy, engageDistance);
        }

        SetTurnDirection();
        
        enemy.GetComponent<EnemyController>().Turn(turnDirection);
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

    private void SetTurnDirection()
    {
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;
        Vector3 leftDetectionRay = enemy.transform.position - enemy.transform.right * rayCastWidth;
        Vector3 rightDetectionRay = enemy.transform.position + enemy.transform.right * rayCastWidth;

        Debug.DrawRay(leftDetectionRay, enemy.transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(rightDetectionRay, enemy.transform.forward * detectionDistance, Color.cyan);

        if (Physics.Raycast(leftDetectionRay, enemy.transform.forward, out hit, detectionDistance))
        {
            raycastOffset += Vector3.right;
        }
        else if (Physics.Raycast(rightDetectionRay, enemy.transform.forward, out hit, detectionDistance))
        {
            raycastOffset -= Vector3.right;
        }

        if (raycastOffset == Vector3.left)
        {
            turnDirection = -1;
        }
        else if (raycastOffset == Vector3.right)
        {
            turnDirection = 1;
        }
        else if (Time.time >= nextDirectionUpdateAt)
        {
            SetRandomDirection();
        }
    }
}
