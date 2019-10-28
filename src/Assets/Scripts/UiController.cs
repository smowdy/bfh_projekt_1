using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{

    [SerializeField] private GameObject Crosshair;

    // Update is called once per frame
    public void Update()
    {
        SetCrosshairPosition();
    }
     
    private void SetCrosshairPosition() {
        Crosshair.transform.position = Input.mousePosition;
    }
}
