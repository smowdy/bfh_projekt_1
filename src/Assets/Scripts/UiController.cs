using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{

    [SerializeField]
    private GameObject Crosshair;

    [SerializeField]
    private GameObject Bar;

    [SerializeField]
    private PlayerController PlayerController;

    // Update is called once per frame
    public void Update()
    {
        SetCrosshairPosition();
        if(PlayerController != null)
        {
            SetHealthbarSize(PlayerController.GetCurrentHealthpointsNormalized());
        }
    }

    private void SetCrosshairPosition()
    {
        Crosshair.transform.position = Input.mousePosition;
    }

    public void SetHealthbarSize(float sizeNormalized)
    {
        Bar.transform.localScale = new Vector3(sizeNormalized, 1f);
    }
}
