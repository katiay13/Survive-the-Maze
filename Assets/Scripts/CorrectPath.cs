using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lights up a spotlight and notifies the player when they're on the correct path
public class CorrectPath : MonoBehaviour
{
    public Light spotLight;

    void Start()
    {
        spotLight.enabled = false; // light off by default
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

    // Turn off spotlight when player leaves the trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spotLight.enabled = false;
        }
    }
}