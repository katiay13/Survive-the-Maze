using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPath : MonoBehaviour
{
    public Light spotLight;

    // Set light to disabled 
    void Start()
    {
        spotLight.enabled = false;
    }


    // Turn on spotlight and notify player when they enter the correct path
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