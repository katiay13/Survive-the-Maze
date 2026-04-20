using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, 90f * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddCoin();
            Destroy(gameObject);
        }
    }
}
