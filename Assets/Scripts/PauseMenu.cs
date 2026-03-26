using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public DeathHandler playerDeathHandler;

    public string mainMenuSceneName = "MainMenu";

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void TogglePause()
    {
        if (playerDeathHandler.isDead) return;
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            pauseButton.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            pauseButton.SetActive(true);
        }
    }

    public void Resume()
    {
        if (isPaused) TogglePause();
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName); // Not implemented yet
    }

    public void ChangeLevel()
    {
        // Add functionality later
    }
}