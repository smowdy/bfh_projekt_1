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
        Debug.Log(maxHealthpoints);
    }

    public void CheckIfDestroyed()
    {
        if(maxHealthpoints <= 0)
        {
            Debug.Log("DESTOYED");
            Destroy(gameObject);
        }
    }

}
