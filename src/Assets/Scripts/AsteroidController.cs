using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Vector3 rotationSpeed;

    [SerializeField]
    private int minScaleChange = 0;
    [SerializeField]
    private int maxScaleChange = 2;

    [SerializeField]
    private int minRotation = 0;
    [SerializeField]
    private int maxRotation = 360;


    void Start()
    {
        int randomScaleChange = getRandomScaleChange();
        transform.localScale += new Vector3(randomScaleChange, randomScaleChange, randomScaleChange);
        rotationSpeed = new Vector3(getRotationAxysValue(), getRotationAxysValue(), getRotationAxysValue());
    }
    
    void Update()
    {
        transform.Rotate(rotationSpeed);
    }

    private float getRotationAxysValue()
    {
        return Random.Range(minRotation, maxRotation) * Time.fixedDeltaTime;
    }

    private int getRandomScaleChange()
    {
        return Random.Range(minScaleChange, maxScaleChange);
    }
}
