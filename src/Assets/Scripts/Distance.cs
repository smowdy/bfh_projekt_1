using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{

    [SerializeField]
    private Text distanceToTarget;
    public GameObject target;
    public GameObject player;
    public float dist;

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(target.transform.position, player.transform.position);
        distanceToTarget.text = "Distance to target: " + dist.ToString("F1") + " meters";
    }
}
