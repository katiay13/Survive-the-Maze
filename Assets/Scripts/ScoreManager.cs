using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
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
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
    }

    public void AddCoin()
    {
        coinCount += coinDoublerActive ? 2 : 1;
        UpdateUI();
    }

    public void StartCoinDoubler()
    {
        StartCoroutine(CoinDoublerCoroutine());
    }

    public void StopCoinDoubler()
    {
        StopAllCoroutines();
        coinDoublerActive = false;
    }

    private IEnumerator CoinDoublerCoroutine()
    {
        coinDoublerActive = true;
        UINotification.instance.ShowNotification("COINS DOUBLED!", Color.green);
        yield return new WaitForSeconds(10f);
        coinDoublerActive = false;
        UINotification.instance.ShowNotification("COINS NORMAL", Color.white);
    }

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