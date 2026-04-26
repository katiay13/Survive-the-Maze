using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchObstacle : MonoBehaviour
{
    // Triggers player death when they collide with this obstacle
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<DeathHandler>().TriggerDeath();
        }
    }
}