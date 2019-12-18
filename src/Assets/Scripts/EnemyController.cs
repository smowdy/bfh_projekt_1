using System.Linq;
using UnityEngine;

public class EnemyController : SpaceShipController
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float engageDistance = 20;

    [SerializeField]
    private float obstacleDetectionDistance = 10f;
    public float ObstacleDetectionDistance
    {
        get { return obstacleDetectionDistance; }
    }

    [SerializeField]
    private float obstacleRayCastWidth = 3.5f;
    public float ObstacleRayCastWidth
    {
        get { return obstacleRayCastWidth; }
    }

    private EnemyState state;

    protected new void Start()
    {
        base.Start();
        state = new EnemyIdleState(gameObject,  engageDistance);
        if(target == null)
        {
            target = GameObject.FindGameObjectsWithTag("player").FirstOrDefault();
        }
    }

    private void Update()
    {
        state = state.Action(target);
    }
}
