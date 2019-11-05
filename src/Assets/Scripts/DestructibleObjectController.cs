using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObjectController : MonoBehaviour
{
    [SerializeField] 
    protected float maxHealthpoints = 100f;
    protected float currentHealtpoints;

    private void Awake()
    {
        currentHealtpoints = maxHealthpoints;
    }

    public void TakesDamage(int amount)
    {
        currentHealtpoints -= amount;
    }

    public void CheckIfDestroyed()
    {
        if(currentHealtpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
