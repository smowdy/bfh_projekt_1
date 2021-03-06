﻿using UnityEngine;

public class DestructibleObjectController : MonoBehaviour
{
    [SerializeField] 
    protected float maxHealthpoints = 100f;

    private float currentHealtpoints;

    public float GetCurrentHealthpointsNormalized()
    {
        if(currentHealtpoints > 0f)
        {
            return currentHealtpoints / maxHealthpoints;
        }
        else
        {
            return 0f;
        }
        
    }

    private void Awake()
    {
        currentHealtpoints = maxHealthpoints;
    }

    protected void OnTriggerEnter(Collider other)
    {
        var destructible = other.gameObject.GetComponent<DestructibleObjectController>();
        if (destructible == null) { return; }

        DamageOtherOnCollision(destructible);
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
            DestroyThisObject();
        }
    }

    public virtual void DestroyThisObject()
    {
        Destroy(gameObject);

        DestructionAnimator animator = GetComponent<DestructionAnimator>();
        if(animator == null) { return; }

        animator.Play();
    }

    protected void DamageOtherOnCollision(DestructibleObjectController destructible)
    {
        destructible.TakesDamage(maxHealthpoints / 5);
    }
}
