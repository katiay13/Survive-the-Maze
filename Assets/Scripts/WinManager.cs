using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Handles the win screen display and post-game options
public class WinManager : MonoBehaviour
{
    public static WinManager instance; // singleton for global access

    public GameObject winPanel;
    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        winPanel.SetActive(false); // hidden at start
    }

    // Displays final score and high score then freezes the game
    public void ShowWinScreen()
    {
        int coins = ScoreManager.instance.coinCount;
        int best = ScoreManager.instance.highScore;
        finalScoreText.text = "COINS COLLECTED: " + coins;
        highScoreText.text = "HIGH SCORE: " + best;
        winPanel.SetActive(true);
        Time.timeScale = 0f; // freeze the game
    }

    // Fully reloads the scene to reset all objects to their starting state
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}