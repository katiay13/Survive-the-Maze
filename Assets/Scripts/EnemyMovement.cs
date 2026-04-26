using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Controls enemy pathfinding and speed boost behavior
public class EnemyMovement : MonoBehaviour
{
    public static EnemyMovement instance; // singleton for global access

    public Transform player;
    private NavMeshAgent navMeshAgent;
    private float baseSpeed;
    public float boostedSpeed = 8f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        baseSpeed = navMeshAgent.speed; // save default speed set in the Inspector
    }

    void Update()
    {
        // Continuously update the enemy's destination to chase the player
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    // Called by beneficial token to temporarily boost enemy speed
    public void StartSpeedBoost()
    {
        StartCoroutine(SpeedBoostCoroutine());
    }

    // Called on player death to cancel any active speed boost
    public void StopSpeedBoost()
    {
        StopAllCoroutines();
        navMeshAgent.speed = baseSpeed;
    }

    private IEnumerator SpeedBoostCoroutine()
    {
        navMeshAgent.speed = boostedSpeed;
        UINotification.instance.ShowNotification("ENEMIES ENRAGED!", Color.red);
        yield return new WaitForSeconds(10f);
        navMeshAgent.speed = baseSpeed;
        UINotification.instance.ShowNotification("ENEMIES CALMED", Color.white);
    }
}