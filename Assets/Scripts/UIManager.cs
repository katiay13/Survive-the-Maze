using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject titlePanel;
    public GameObject pausePanel;

    private bool isPaused = false;

    void Start()
    {
        // Always start on title screen
        ShowTitleScreen();
    }

    void Update()
    {
        // Only allow pause if title screen is hidden
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

    // ---- Quit to Title ----
    public void QuitToTitle()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        ShowTitleScreen();
    }
}