using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Handles pause menu visibility and game pausing/resuming
public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public DeathHandler playerDeathHandler;
    public string mainMenuSceneName = "MainMenu";

    private bool isPaused = false;

    void Start()
    {
        // Ensure pause menu is hidden at the start
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void TogglePause()
    {
        if (playerDeathHandler.isDead) return; // disallow pausing during death sequence

        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // freeze the game
            pausePanel.SetActive(true);
            pauseButton.SetActive(false); // hide pause button while menu is open
        }
        else
        {
            Time.timeScale = 1f; // resume the game
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
        // Add functionality later if there is time
    }
}