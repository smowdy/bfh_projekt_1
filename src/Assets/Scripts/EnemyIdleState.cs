using System.Timers;
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
        if((target.transform.position - enemy.transform.position).magnitude < engageDistance)
        {
            return new EnemyEngageState(enemy, engageDistance);
        }

        if(Time.time >= nextDirectionUpdateAt)
        {
            SetRandomDirection();
        }

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
}
