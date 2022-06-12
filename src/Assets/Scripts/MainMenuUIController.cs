using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync("CampusScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
