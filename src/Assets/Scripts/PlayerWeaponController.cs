using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : WeaponController
{
    private void Update()
    {
        AimToCursorPosition();
        HandleShootInput();
    }

    private void AimToCursorPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(transform.up, transform.position);
        if (plane.Raycast(ray, out float distance))
        {
            Vector3 targetPosition = ray.GetPoint(distance);
            Aim(targetPosition - transform.position);
        }
    }

    private void HandleShootInput()
    {
        if (!(Input.GetAxis("Fire1") > 0)) { return; }
        TryShoot();
    }
}
