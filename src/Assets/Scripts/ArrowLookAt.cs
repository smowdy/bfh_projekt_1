using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLookAt : MonoBehaviour
{

    [SerializeField]
    Transform goal;
    [SerializeField]
    Transform player;

    void Update()
    {
        Vector3 directionToGoal = goal.position - player.position;
        //transform.LookAt(targetPosition);
        //Vector3 rotationVector = new Vector3(0, 0, Quaternion.LookRotation(directionToGoal).eulerAngles.y);
        //transform.eulerAngles = rotationVector;
        Quaternion rotation = Quaternion.LookRotation(directionToGoal, Vector3.up);
        transform.rotation = rotation;
    }
}
