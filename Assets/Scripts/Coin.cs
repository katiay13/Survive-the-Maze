using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, 0f, 90f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddCoin();
            gameObject.SetActive(false); // hides it instead of destroying it
        }
    }

}
