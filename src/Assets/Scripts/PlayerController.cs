using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform myTransform;

    [SerializeField]float movementSpeed = 32f;
    [SerializeField]float turnSpeed = 40f;

    private void Start()
    {
        myTransform = transform;
    }
    // Update is called once per frame
    void Update()
    {
        Turn();
        Thrust();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");

        myTransform.Rotate(0, yaw, 0);
    }
    void Thrust() {
        myTransform.position += transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");

    }

}
