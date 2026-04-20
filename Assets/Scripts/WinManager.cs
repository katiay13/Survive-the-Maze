using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinManager : MonoBehaviour
{
    public static WinManager instance;

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

    public void ShowWinScreen()
    {
        // Pull the values from ScoreManager to display
        int coins = ScoreManager.instance.coinCount;
        int best = ScoreManager.instance.highScore;

        finalScoreText.text = "COINS COLLECTED: " + coins;
        highScoreText.text = "HIGH SCORE: " + best;

        winPanel.SetActive(true);
        Time.timeScale = 0f; // freeze the game
    }

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