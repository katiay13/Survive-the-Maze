using UnityEngine;

public class EnemyContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<DeathHandler>().TriggerDeath();
        }
    }
}