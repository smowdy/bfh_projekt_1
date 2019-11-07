using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.transform.position;
        targetPosition.z = transform.position.z;
        transform.LookAt(targetPosition);
        
        Debug.Log(targetPosition);
    }
}