using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{

    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private RectTransform Arrow;
    [SerializeField]
    private Transform Target;
    [SerializeField]
    private Transform Player;

    private Quaternion lookRotation;
    private Vector3 direction;

    // Update is called once per frame
    public void Update()
    {
        SetCrosshairPosition();
        setArrowPosition();
    }

    private void SetCrosshairPosition()
    {
        Crosshair.transform.position = Input.mousePosition;
    }

    private void setArrowPosition()
    {
        //find the vector pointing from our position to the target
        direction = (Target.position + Arrow.position).normalized;

        //create the rotation we need to be in to look at the target
        lookRotation = Quaternion.LookRotation(direction);

        //rotate us over time according to speed until we are in the required rotation
        Arrow.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);

    }
}
