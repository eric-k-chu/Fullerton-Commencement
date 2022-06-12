
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public enum States { Running, Paused };

    private States currentState;

    private void Start()
    {
        currentState = States.Running;
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        switch (currentState)
        {
            case States.Running:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    TransitionState(States.Paused);
                }
                break;
            case States.Paused:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    TransitionState(States.Running);
                }
                break;
            default:
                break;
        }
    }

    void TransitionState(States state)
    {
        OnStateExit(currentState);
        OnStateEnter(state);
    }

    void OnStateExit(States state)
    {
        switch (state)
        {
            case States.Running:
                break;
            case States.Paused:
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                pauseMenu?.SetActive(false);
                break;
            default:
                break;
        }
    }

    void OnStateEnter(States state)
    {
        currentState = state;
        switch (currentState)
        {
            case States.Running:
                break;
            case States.Paused:
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                pauseMenu?.SetActive(true);
                break;
            default:
                break;
        }
    }

}
