using UnityEngine;
using UnityEngine.SceneManagement;

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

    public override void DestroyThisObject()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}