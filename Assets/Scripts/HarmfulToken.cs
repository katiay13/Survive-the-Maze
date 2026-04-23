using UnityEngine;
using System.Collections;
public class HarmfulToken : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnemyMovement.instance.StartSpeedBoost();
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
