using UnityEngine;
using TMPro;
using System.Collections;

// Manages coin score, high score, and the coin doubler powerup
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // singleton for global access

    public TMP_Text coinCountText;
    public TMP_Text highScoreText;
    public int coinCount = 0;
    public int highScore = 0;
    public bool coinDoublerActive = false;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0); // load saved high score on startup
        UpdateUI();
    }

    public void AddCoin()
    {
        coinCount += coinDoublerActive ? 2 : 1; // doubles coin value when powerup is active
        UpdateUI();
    }

    // Called by beneficial token to start the coin doubler
    public void StartCoinDoubler()
    {
        StartCoroutine(CoinDoublerCoroutine());
    }

    // Called on player death to cancel any active coin doubler
    public void StopCoinDoubler()
    {
        StopAllCoroutines();
        coinDoublerActive = false;
    }

    // Activates coin doubler for 10 seconds, notifying the player at start and end
    private IEnumerator CoinDoublerCoroutine()
    {
        coinDoublerActive = true;
        UINotification.instance.ShowNotification("COINS DOUBLED!", Color.green);
        yield return new WaitForSeconds(10f);
        coinDoublerActive = false;
        UINotification.instance.ShowNotification("COINS NORMAL", Color.white);
    }

    // Resets coin count and re-enables all collectibles after player death
    public void ResetCoins()
    {
        coinCount = 0;
        coinDoublerActive = false;

        Coin[] allCoins = FindObjectsOfType<Coin>(true);
        foreach (Coin coin in allCoins)
            coin.gameObject.SetActive(true);

        BeneficialToken[] beneficialTokens = FindObjectsOfType<BeneficialToken>(true);
        foreach (BeneficialToken token in beneficialTokens)
            token.gameObject.SetActive(true);

        HarmfulToken[] harmfulTokens = FindObjectsOfType<HarmfulToken>(true);
        foreach (HarmfulToken token in harmfulTokens)
            token.gameObject.SetActive(true);

        UpdateUI();
    }

    // Saves high score to disk if current score beats it
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

    // Refreshes the HUD coin and high score display
    void UpdateUI()
    {
        if (coinCountText != null)
            coinCountText.text = "COINS: " + coinCount;
        if (highScoreText != null)
            highScoreText.text = "BEST: " + highScore;
    }
}