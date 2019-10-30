using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    [SerializeField]
    [Range(1f, 10f)]
    private float cameraSpeed = 1f;

    // Update is called once per frame
    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 targetPosition = new Vector3(playerObject.transform.position.x, transform.position.y, playerObject.transform.position.z);
        transform.position = Vector3.Slerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        Quaternion targetRotation = Quaternion.LookRotation(-playerObject.transform.up, playerObject.transform.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, cameraSpeed * Time.deltaTime);
    }
}
