using UnityEngine;
using UnityEngine.AI;
using System.Collections;

// Handles the harmful token pickup - teleports the enemy closer to the player when collected
public class HarmfulToken : MonoBehaviour
{
    public float spawnRadius = 5f; // how close to the player the enemy teleports
    public AudioClip tokenSound;
    private AudioSource audioSource;

    void Start()
    {
        // Add and configure AudioSource at runtime
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportEnemyNearPlayer(other.transform);
            GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<MeshRenderer>().enabled = false; // hide token visually
            GetComponent<Collider>().enabled = false;     // prevent re-triggering
            if (tokenSound != null)
                audioSource.PlayOneShot(tokenSound);
            UINotification.instance.ShowNotification("ENEMIES ENRAGED!", Color.red);
            StartCoroutine(Deactivate());
        }
    }

    private void TeleportEnemyNearPlayer(Transform player)
    {
        // Pick a random position near the player and snap it to the nearest valid NavMesh point
        Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
        randomOffset.y = 0f; // keep enemy on the ground
        Vector3 targetPos = player.position + randomOffset;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPos, out hit, spawnRadius, NavMesh.AllAreas))
        {
            // Warp cleanly moves the NavMeshAgent without physics conflicts
            EnemyMovement.instance.GetComponent<NavMeshAgent>().Warp(hit.position);
        }
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(1.5f); // wait for particle effect to finish
        gameObject.SetActive(false);
    }
}