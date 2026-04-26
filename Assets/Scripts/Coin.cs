using UnityEngine;
using System.Collections;
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
            // Add coin to score and hide it while the particle effect plays
            ScoreManager.instance.AddCoin();
            GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            StartCoroutine(Deactivate());
        }
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
