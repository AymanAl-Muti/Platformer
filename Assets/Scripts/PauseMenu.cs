using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private Canvas pauseMenuCanvas;
    private bool paused;
    private float timeScaleBeforePause;

    private void Awake()
    {
        pauseMenuCanvas = GetComponent<Canvas>();
        paused = false;
    }

    private void Pause()
    {
        timeScaleBeforePause = Time.timeScale;
        Time.timeScale = 0;

        pauseMenuCanvas.enabled = true;
        paused = true;
    }

    private void Unpause()
    {
        Time.timeScale = timeScaleBeforePause;

        pauseMenuCanvas.enabled = false;
        paused = false;
    }

    public void OnPauseKeyPressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(!paused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    public void OnResumeButtonPressed()
    {
        Unpause();
    }

    public void OnExitButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}