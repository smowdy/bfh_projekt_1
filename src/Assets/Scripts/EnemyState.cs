using UnityEngine;

public abstract class EnemyState
{
    protected static float ENGAGE_DISTANCE = 20;

    protected GameObject Enemy;

    public EnemyState(GameObject Enemy)
    {
        this.Enemy = Enemy;
    }

    public abstract EnemyState Action(GameObject target);
}
