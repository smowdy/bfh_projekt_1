using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerObject = null;

    [SerializeField]
    [Range(1f, 10f)]
    private float cameraSpeed = 1f;

    private void FixedUpdate()
    {
        if (playerObject == null) { return; }
        //Player moves in FixedUpdate so Camera should move in FixedUpdate too
        Move(Time.fixedDeltaTime);
    }

    private void Move(float deltaTime)
    {
        Vector3 targetPosition = new Vector3(playerObject.position.x, transform.position.y, playerObject.position.z);
        transform.position = Vector3.Slerp(transform.position, targetPosition, cameraSpeed * deltaTime);
    }
}
