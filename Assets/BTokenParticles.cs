using UnityEngine;

public class BTokenParticles : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, 0f, 90f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject, 1.5f);
        }
    }
}