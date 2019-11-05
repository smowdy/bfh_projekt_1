using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObjectController : MonoBehaviour
{
    [SerializeField] 
    protected float maxHealthpoints = 100f;

    public void TakesDamage(int amount)
    {
        maxHealthpoints -= amount; 
    }

    private void Update()
    {
        CheckIfDestroyed();
    }

    private void CheckIfDestroyed()
    {
        if(maxHealthpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

}
