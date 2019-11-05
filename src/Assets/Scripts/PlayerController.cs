using UnityEngine;

public class PlayerController : SpaceShipController
{

    private void Update()
    {
        Turn();
        Thrust();
        
    }

    private void Turn()
    {
        Turn(Input.GetAxis("Horizontal"));
    }

    private void Thrust()
    {
        Thrust(Input.GetAxis("Vertical"));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("TRIGGER2D");
        Destroy(collision.gameObject);
        
    }
}