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
        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;

        deathPanel.SetActive(true);

        yield return new WaitForSeconds(displayDuration);

        deathPanel.SetActive(false);

        // Reset player
        transform.position = respawnPoint.position;
        rb.isKinematic = false;

        // Reset enemy
        enemy.position = enemySpawnPoint.position;

        isDead = false;
    }
}