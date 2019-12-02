using UnityEngine;

public class EnemyEngageState : EnemyState
{
    private float nextDirectionUpdateAt = 0;
    private Vector3 currentDirection;

    public EnemyEngageState(GameObject Enemy) : base(Enemy) { }

    public override EnemyState Action(GameObject target)
    {
        if ((target.transform.position - Enemy.transform.position).magnitude > ENGAGE_DISTANCE)
        {
            Debug.Log("Enemy Idle");
            return new EnemyIdleState(Enemy);
        }

        Enemy.GetComponent<EnemyController>().Turn(GetDirection(target.transform.position));
        Enemy.GetComponent<EnemyController>().Thrust(1);
        return this;
    }

    private Vector3 GetDirection(Vector3 targetPosition)
    {
        if (Time.time < nextDirectionUpdateAt) { return currentDirection; }

        Vector2 random2DVector = Random.insideUnitCircle;
        Vector3 randomVector = new Vector3(random2DVector.x, 0, random2DVector.y);

        currentDirection = targetPosition - Enemy.transform.position +
            randomVector * (ENGAGE_DISTANCE/2);
        nextDirectionUpdateAt = Time.time + Random.Range(0, 2);

        return currentDirection;
    }
}
