using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text coinCountText;
    public TMP_Text highScoreText;

    public int coinCount = 0;
    public int highScore = 0;

    void Awake()
    {
        // Singleton so any script can call ScoreManager.instance
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0); // load saved high score
        UpdateUI();
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateUI();
    }

    public void ResetCoins()
    {
        coinCount = 0;

        // find every coin in the scene and reactivate it
        Coin[] allCoins = FindObjectsOfType<Coin>(true); // true = include inactive
        foreach (Coin coin in allCoins)
        {
            coin.gameObject.SetActive(true);
        }

        UpdateUI();
    }

    public void CheckAndSaveHighScore()
    {
        if (coinCount > highScore)
        {
            highScore = coinCount;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        if (coinCountText != null)
            coinCountText.text = "COINS: " + coinCount;
        if (highScoreText != null)
            highScoreText.text = "BEST: " + highScore;
    }
}