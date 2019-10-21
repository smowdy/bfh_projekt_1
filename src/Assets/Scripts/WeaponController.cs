using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    private void Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(transform.up, transform.position);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 targetPosition = ray.GetPoint(distance);
            Vector3 direction = targetPosition - transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }
    }
}
