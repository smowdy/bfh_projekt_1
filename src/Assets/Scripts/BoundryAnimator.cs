using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundryAnimator: MonoBehaviour
{

    [SerializeField]
    private GameObject particleSystemPrefab = null;

    [SerializeField]
    private float spawnPositionOffset = 0f;

    void Start()
    {
        if(particleSystemPrefab == null) { return; }
        SpawnForwardBorder();
        SpawnBackBorder();
        SpawnRightBorder();
        SpawnLeftdBorder();
    }

    private void SpawnForwardBorder()
    {
        Vector3 position = transform.position + 
            transform.forward * (transform.localScale.z / 2 + spawnPositionOffset);
        SpawnAsteroidBelt(
            position, 
            Quaternion.LookRotation(transform.right), 
            transform.localScale.x
        );
        SpawnAsteroidBelt(
            position,
            Quaternion.LookRotation(-transform.right),
            transform.localScale.x
        );
    }

    private void SpawnRightBorder()
    {
        Vector3 position = transform.position +
            transform.right * (transform.localScale.z / 2 + spawnPositionOffset);
        SpawnAsteroidBelt(
            position, 
            Quaternion.LookRotation(transform.forward), 
            transform.localScale.z
        );
        SpawnAsteroidBelt(
            position,
            Quaternion.LookRotation(-transform.forward),
            transform.localScale.z
        );
    }

    private void SpawnLeftdBorder()
    {
        Vector3 position = transform.position +
            -transform.right * (transform.localScale.z / 2 + spawnPositionOffset);
        SpawnAsteroidBelt(
            position,
            Quaternion.LookRotation(transform.forward),
            transform.localScale.z
        );
        SpawnAsteroidBelt(
            position,
            Quaternion.LookRotation(-transform.forward),
            transform.localScale.z
        );
    }

    private void SpawnBackBorder()
    {
        Vector3 position = transform.position +
            -transform.forward * (transform.localScale.z / 2 + spawnPositionOffset);
        SpawnAsteroidBelt(
            position, 
            Quaternion.LookRotation(transform.right), 
            transform.localScale.x
        );
        SpawnAsteroidBelt(
            position,
            Quaternion.LookRotation(-transform.right),
            transform.localScale.x
        );
    }

    private void SpawnAsteroidBelt(Vector3 position, Quaternion rotation, float borderLengt)
    {
        GameObject newAsteroidBelt = Instantiate(particleSystemPrefab, position, rotation, transform);
        ParticleSystem particleSystem = newAsteroidBelt.GetComponent<ParticleSystem>();
        ParticleSystem.ShapeModule shape = particleSystem.shape;
        Vector3 newScale = shape.scale;
        newScale.z = borderLengt;
        shape.scale = newScale;
    }
}
