using UnityEngine;
using System.Collections;

// Handles the beneficial token pickup - activates coin doubler when collected by the player
public class BeneficialToken : MonoBehaviour
{
    public AudioClip tokenSound;
    private AudioSource audioSource;

    void Start()
    {
        // Add and configure AudioSource at runtime
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // Activate coin doubler and hide the token while the particle effect plays
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.StartCoinDoubler();
            GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<MeshRenderer>().enabled = false; // hide token visually
            GetComponent<Collider>().enabled = false;     // prevent re-triggering
            if (tokenSound != null)
                audioSource.PlayOneShot(tokenSound);
            StartCoroutine(Deactivate());
        }
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(1.5f); // wait for particle effect to finish
        gameObject.SetActive(false);
    }
}