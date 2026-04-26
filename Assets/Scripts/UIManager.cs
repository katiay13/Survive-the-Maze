using UnityEngine;
using UnityEngine.SceneManagement;

// Manages the title screen, pause menu, and game flow
public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject titlePanel;
    public GameObject pausePanel;

    private bool isPaused = false;

    void Start()
    {
        ShowTitleScreen();
    }

    void Update()
    {
        // Allow escape key to toggle pause only when title screen is not showing
        if (!titlePanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused) ResumeGame();
                else PauseGame();
            }
        }
    }

    // ---- Title Screen ----
    public void ShowTitleScreen()
    {
        titlePanel.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 0f; // freeze game while on title screen
        isPaused = false;
    }

    public void PlayGame()
    {
        titlePanel.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    // ---- Pause Menu ----
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f; // freeze game while paused
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    // Fully reloads the scene to reset all objects to their starting state
    public void RestartGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}