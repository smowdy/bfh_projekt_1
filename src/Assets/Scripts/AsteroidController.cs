using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    Vector3 rotationSpeed;

    int minScaleChange = -2;
    int maxScaleChange = 2;
    void Start()
    {
        int randomScaleChange = getRandomScaleChange();
        transform.localScale += new Vector3(randomScaleChange, randomScaleChange, randomScaleChange);
        rotationSpeed = new Vector3(getRotationAxysValue(), getRotationAxysValue(), getRotationAxysValue());
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed);
    }

    private float getRotationAxysValue()
    {
        return Random.Range(0, 360) * Time.deltaTime;
    }

    private int getRandomScaleChange()
    {
        return Random.Range(minScaleChange, maxScaleChange);
    }
}
