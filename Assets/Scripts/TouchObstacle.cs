using UnityEngine;
using UnityEngine.SceneManagement;

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