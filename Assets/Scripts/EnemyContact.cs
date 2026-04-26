using UnityEngine;

// Triggers player death when the enemy makes contact
public class EnemyContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Player dies if enemy is touched
        if (other.CompareTag("Player"))
        {
            other.GetComponent<DeathHandler>().TriggerDeath();
        }
    }
}