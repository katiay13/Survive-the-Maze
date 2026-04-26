using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPath : MonoBehaviour
{
    public Light spotLight;

    void Start()
    {
        spotLight.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spotLight.enabled = true;
            UINotification.instance.ShowNotification("CORRECT PATH!", Color.green);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spotLight.enabled = false;
        }
    }
}