using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public static EnemyMovement instance;

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
        baseSpeed = navMeshAgent.speed; // saves whatever speed you set in the Inspector
    }

    void Update()
    {
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    public void StartSpeedBoost()
    {
        StartCoroutine(SpeedBoostCoroutine());
    }

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