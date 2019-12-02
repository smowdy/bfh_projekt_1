using UnityEngine;

public abstract class EnemyState
{
    protected GameObject enemy;
    protected float engageDistance;

    public EnemyState(GameObject Enemy, float engageDistance)
    {
        this.enemy = Enemy;
        this.engageDistance = engageDistance;
    }

    public abstract EnemyState Action(GameObject target);
}
