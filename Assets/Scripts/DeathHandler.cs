using System.Collections;
using UnityEngine;

// Handles player death, respawn, and resetting the game state
public class DeathHandler : MonoBehaviour
{
    [Header("UI")]
    public GameObject deathPanel;
    public float displayDuration = 2f;

    [Header("Respawn")]
    public Transform respawnPoint;
    public Transform enemy;
    public Transform enemySpawnPoint;

    [Header("Pause")]
    public GameObject pauseButton;

    private Rigidbody rb;
    public bool isDead = false; // public so other scripts can check if player is currently dead

    private GameObject[] coins;
    private GameObject[] tokens;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        deathPanel.SetActive(false);

        // Cache all coins and tokens in the scene at start
        coins = GameObject.FindGameObjectsWithTag("Coin");
        tokens = GameObject.FindGameObjectsWithTag("Token");
    }

    public void TriggerDeath()
    {
        if (isDead) return; // prevent death from triggering multiple times at once
        isDead = true;

        // Stop any active powerups and reset score before showing death screen
        ScoreManager.instance.StopCoinDoubler();
        EnemyMovement.instance.StopSpeedBoost();
        ScoreManager.instance.ResetCoins();
        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        // Freeze player and show death panel
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        deathPanel.SetActive(true);
        pauseButton.SetActive(false); // hide pause button during death screen

        yield return new WaitForSeconds(displayDuration);

        // Respawn player and enemy, then re-enable all coins and tokens
        deathPanel.SetActive(false);
        pauseButton.SetActive(true);
        transform.position = respawnPoint.position;
        rb.isKinematic = false;
        enemy.position = enemySpawnPoint.position;

        foreach (GameObject coin in coins)
        {
            coin.SetActive(true);
            coin.GetComponent<MeshRenderer>().enabled = true;
            coin.GetComponent<Collider>().enabled = true;
        }

        foreach (GameObject token in tokens)
        {
            token.SetActive(true);
            token.GetComponent<MeshRenderer>().enabled = true;
            token.GetComponent<Collider>().enabled = true;
        }

        isDead = false;
    }
}