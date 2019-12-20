using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player") {
            SceneManager.LoadScene("GameCompleteScene", LoadSceneMode.Single);
        }
    }
}
