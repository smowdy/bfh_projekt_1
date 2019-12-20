using UnityEngine;

public class DestructionAnimator : MonoBehaviour
{
    [SerializeField]
    private GameObject destructionParticleSystem = null;

    public void Play()
    {
        if(destructionParticleSystem == null) { return; }
        Instantiate(destructionParticleSystem, transform.position, transform.rotation);
    }
}
