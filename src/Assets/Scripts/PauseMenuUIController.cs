using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUIController : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadSceneAsync("CampusScene");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadSceneAsync("MainMenuScene");
    }
}
