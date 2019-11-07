using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObjectController : MonoBehaviour
{
    [SerializeField] 
    protected float maxHealthpoints = 100f;
    private float currentHealtpoints;

    public float GetCurrentHealthpointsNormalized()
    {
        return currentHealtpoints / maxHealthpoints;
    }

    private void Awake()
    {
        currentHealtpoints = maxHealthpoints;
    }

    public void TakesDamage(float amount)
    {
        currentHealtpoints -= amount;
        CheckIfDestroyed();
    }

    private void CheckIfDestroyed()
    {
        if(currentHealtpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
