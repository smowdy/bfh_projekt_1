using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionAnimator : MonoBehaviour
{
    [SerializeField]
    private GameObject destructionParticleSystem;

    public void Play()
    {
        Instantiate(destructionParticleSystem, transform.position, transform.rotation);
    }
}
