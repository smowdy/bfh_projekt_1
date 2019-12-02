using System.Timers;
using UnityEngine;

public class EnemyIdleState : EnemyState
{

    private float turnDirection = 1;
    private float nextDirectionUpdateAt = 0;

    public EnemyIdleState(GameObject Enemy) : base(Enemy) {
        SetRandomDirection();
    }

    public override EnemyState Action(GameObject target)
    {
        if((target.transform.position - Enemy.transform.position).magnitude < ENGAGE_DISTANCE)
        {
            Debug.Log("Enemy Engage");
            return new EnemyEngageState(Enemy);
        }

        if(Time.time >= nextDirectionUpdateAt)
        {
            SetRandomDirection();
        }

        Enemy.GetComponent<EnemyController>().Turn(turnDirection);
        Enemy.GetComponent<EnemyController>().Thrust(1);
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
