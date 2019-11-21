using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour

    
{
    [SerializeField]
    RectTransform parent;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform rectTransform = transform.GetComponent<RectTransform>();
        transform.localPosition = new Vector3(-parent.rect.width/2 + rectTransform.rect.width/2 + 50, -parent.rect.height/2 + rectTransform.rect.height/2 + 50, 0);
    }
}
