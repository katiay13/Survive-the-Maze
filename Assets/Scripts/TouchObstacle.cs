using UnityEngine;
using UnityEngine.SceneManagement;

// Triggers player death when they collide with this obstacle
public class TouchObstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<DeathHandler>().TriggerDeath();
        }
    }
}