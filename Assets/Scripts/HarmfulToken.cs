using UnityEngine;

public class HarmfulToken : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnemyMovement.instance.StartSpeedBoost();
            gameObject.SetActive(false);
        }
    }
}