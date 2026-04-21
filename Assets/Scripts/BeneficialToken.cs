using UnityEngine;
using System.Collections;

public class BeneficialToken : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.StartCoinDoubler();
            gameObject.SetActive(false);
        }
    }
}