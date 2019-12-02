using UnityEngine;

public class EnemyEngageState : EnemyState
{
    private float nextDirectionUpdateAt = 0;
    private Vector3 currentDirection;

    public EnemyEngageState(GameObject enemy, float engageDistance) : base(enemy, engageDistance) { }

    public override EnemyState Action(GameObject target)
    {
        if ((target.transform.position - enemy.transform.position).magnitude > engageDistance)
        {
            return new EnemyIdleState(enemy, engageDistance);
        }

        enemy.GetComponent<EnemyController>().Turn(GetDirection(target.transform.position));
        enemy.GetComponent<EnemyController>().Thrust(1);
        return this;
    }

    private Vector3 GetDirection(Vector3 targetPosition)
    {
        if (Time.time < nextDirectionUpdateAt) { return currentDirection; }

        Vector2 random2DVector = Random.insideUnitCircle;
        Vector3 randomVector = new Vector3(random2DVector.x, 0, random2DVector.y);

        currentDirection = targetPosition - enemy.transform.position +
            randomVector * (engageDistance/2);
        nextDirectionUpdateAt = Time.time + Random.Range(0, 2);

        return currentDirection;
    }
}
