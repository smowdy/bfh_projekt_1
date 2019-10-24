using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]float movementSpeed = 32f;
    [SerializeField]float turnSpeed = 80f;

    // Update is called once per frame
    void Update()
    {
        Turn();
        Thrust();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.Rotate(0, yaw, 0);
    }

    void Thrust() {
        transform.position += transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
    }
}