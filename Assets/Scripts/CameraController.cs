using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps the camera following the player at a fixed offset
public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        // Calculate the initial distance between camera and player
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // LateUpdate ensures the player has finished moving before the camera follows
        transform.position = player.transform.position + offset;
    }
}