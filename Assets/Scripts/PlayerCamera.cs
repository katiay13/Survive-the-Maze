using UnityEngine;

// Smooth third-person camera that orbits the player when right mouse button is held
public class PlayerCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform player;
    public Vector3 offset = new Vector3(0, 2, -4);

    [Header("Camera Settings")]
    public float smoothSpeed = 10f;
    public float mouseSensitivity = 3f;
    public float minYAngle = -20f;
    public float maxYAngle = 60f;
    public bool invertY = false;

    private float currentY = 0f; // vertical orbit angle
    private float currentX = 0f; // horizontal orbit angle

    void LateUpdate()
    {
        if (player == null) return;

        // Only rotate the camera while right mouse button is held
        float mouseX = 0f;
        float mouseY = 0f;
        if (Input.GetMouseButton(1))
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
        }

        currentY += invertY ? mouseY * mouseSensitivity : -mouseY * mouseSensitivity;
        currentX += mouseX * mouseSensitivity;
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle); // clamp vertical angle

        // Move and rotate the camera toward the desired position behind the player
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = player.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Smoothly look at a point slightly above the player
        Vector3 lookTarget = player.position + Vector3.up * 1.5f;
        Quaternion desiredRotation = Quaternion.LookRotation(lookTarget - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothSpeed * Time.deltaTime);
    }
}