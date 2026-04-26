using UnityEngine;
using System.Collections;
public class BeneficialToken : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Activate coin doubler and hide the token while the particle effect plays
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.StartCoinDoubler();
            GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            StartCoroutine(Deactivate());
        }
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(1.5f); // Wait for particle effect to finish
        gameObject.SetActive(false);
    }
}