using UnityEngine;

public class EnemyIdleState : EnemyState
{

    private float turnDirection = 1;
    private float nextDirectionUpdateAt = 0;

    public EnemyIdleState(GameObject enemy, float engageDistance) : base(enemy, engageDistance) {
        SetRandomDirection();
    }

    public override EnemyState Action(GameObject target)
    {
        if(Vector3.Distance(target.transform.position, enemy.transform.position) < engageDistance)
        {
            return new EnemyEngageState(enemy, engageDistance);
        }

        EnemyController enemyController = enemy.GetComponent<EnemyController>();

        SetTurnDirection(enemy.transform, enemyController);

        enemyController.Turn(turnDirection);
        enemyController.Thrust(1);
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

    private void SetTurnDirection(Transform enemyTransform, EnemyController enemyController)
    {
        Vector3 leftDetectionRay = enemyTransform.position - enemyTransform.right * enemyController.ObstacleRayCastWidth;
        Vector3 rightDetectionRay = enemyTransform.position + enemyTransform.right * enemyController.ObstacleRayCastWidth;

        Debug.DrawRay(leftDetectionRay, enemyTransform.forward * enemyController.ObstacleDetectionDistance, Color.cyan);
        Debug.DrawRay(rightDetectionRay, enemyTransform.forward * enemyController.ObstacleDetectionDistance, Color.cyan);

        if (Physics.Raycast(leftDetectionRay, enemyTransform.forward, enemyController.ObstacleDetectionDistance))
        {
            turnDirection = 1;
        }
        else if (Physics.Raycast(rightDetectionRay, enemyTransform.forward, enemyController.ObstacleDetectionDistance))
        {
            turnDirection = -1;
        }
        else if (Time.time >= nextDirectionUpdateAt)
        {
            SetRandomDirection();
        }        
    }
}
