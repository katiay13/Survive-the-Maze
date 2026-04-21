using System.Collections;
using UnityEngine;

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
    public bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        deathPanel.SetActive(false);
    }

    public void TriggerDeath()
    {
        if (isDead) return;
        isDead = true;
        ScoreManager.instance.StopCoinDoubler();
        EnemyMovement.instance.StopSpeedBoost();
        ScoreManager.instance.ResetCoins();
        ScoreManager.instance.ResetCoins();
        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;

        deathPanel.SetActive(true);
        pauseButton.SetActive(false);

        yield return new WaitForSeconds(displayDuration);

        deathPanel.SetActive(false);
        pauseButton.SetActive(true);

        transform.position = respawnPoint.position;
        rb.isKinematic = false;

        enemy.position = enemySpawnPoint.position;

        isDead = false;
    }
}