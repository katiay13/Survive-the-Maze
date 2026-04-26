using UnityEngine;
using System.Collections;

// Handles coin collection, rotation animation, and sound
public class Coin : MonoBehaviour
{
    public AudioClip coinSound;
    private AudioSource audioSource;

    void Start()
    {
        // Add and configure AudioSource at runtime
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        // Spin the coin continuously for visual feedback
        transform.Rotate(0f, 0f, 90f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add coin to score and hide it while the particle effect plays
            ScoreManager.instance.AddCoin();
            GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<MeshRenderer>().enabled = false; // hide coin visually
            GetComponent<Collider>().enabled = false;     // prevent re-triggering
            if (coinSound != null)
                audioSource.PlayOneShot(coinSound);
            StartCoroutine(Deactivate());
        }
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(1.5f); // wait for particle effect to finish
        gameObject.SetActive(false);
    }
}