using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 2, -4);
    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + player.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.LookAt(player);
    }
}

