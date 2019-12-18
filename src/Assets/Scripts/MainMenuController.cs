using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField]
    private string sceneNameToLoad = string.Empty;

    public void StartGameClicked()
    {
        SceneManager.LoadScene(sceneNameToLoad, LoadSceneMode.Single);
    }
}
