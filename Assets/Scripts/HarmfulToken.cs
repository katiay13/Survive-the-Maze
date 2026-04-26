using UnityEngine;
using UnityEngine.AI;

public class HarmfulToken : MonoBehaviour
{
    public float spawnRadius = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportEnemyNearPlayer(other.transform);
            Destroy(gameObject);
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
}