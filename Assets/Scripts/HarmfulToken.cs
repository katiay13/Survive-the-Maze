using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class HarmfulToken : MonoBehaviour
{
    public float spawnRadius = 5f;
    public AudioClip tokenSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportEnemyNearPlayer(other.transform);
            GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            if (tokenSound != null)
                audioSource.PlayOneShot(tokenSound);
            UINotification.instance.ShowNotification("ENEMIES ENRAGED!", Color.red);
            StartCoroutine(Deactivate());
        }
    }

    private void TeleportEnemyNearPlayer(Transform player)
    {
        Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
        randomOffset.y = 0f;
        Vector3 targetPos = player.position + randomOffset;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPos, out hit, spawnRadius, NavMesh.AllAreas))
        {
            EnemyMovement.instance.GetComponent<NavMeshAgent>().Warp(hit.position);
        }
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}