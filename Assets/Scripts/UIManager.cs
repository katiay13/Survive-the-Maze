using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (!titlePanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                    ResumeGame();
                else
                    PauseGame();
            }
        }
    }

    // ---- Title Screen ----
    public void ShowTitleScreen()
    {
        titlePanel.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 0f;
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
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}