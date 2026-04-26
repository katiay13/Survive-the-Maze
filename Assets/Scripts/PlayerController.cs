using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

// Handles player movement relative to the camera direction
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Reads WASD/joystick input from the Input System
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        // Calculate movement direction relative to the camera so controls feel consistent
        Camera cam = Camera.main;
        Vector3 camForward = cam.transform.forward;
        Vector3 camRight = cam.transform.right;

        camForward.y = 0f; // flatten to ignore camera tilt
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        // Apply force in the camera-relative direction
        Vector3 relativeMovement = (camForward * movementY + camRight * movementX);
        rb.AddForce(relativeMovement * speed);
    }
}