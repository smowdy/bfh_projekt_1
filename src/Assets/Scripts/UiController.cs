using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{

    public GameObject Crosshair;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        SetCrosshairPosition();
    }
     
    private void SetCrosshairPosition() {
        Crosshair.transform.position = Input.mousePosition;
    }
}
