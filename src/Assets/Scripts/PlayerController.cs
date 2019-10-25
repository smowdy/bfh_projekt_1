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

    private void Thrust() {
        Thrust(Input.GetAxis("Vertical"));
    }
}