using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Continuously rotates an object, used for spinning collectibles
public class Rotator : MonoBehaviour
{
    void Update()
    {
        // Rotate on all three axes at different speeds for a tumbling effect
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}