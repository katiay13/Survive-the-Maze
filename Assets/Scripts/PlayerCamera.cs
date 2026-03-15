using UnityEngine;

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

    private float currentY = 0f;
    private float currentX = 0f;

    void LateUpdate()
    {
        if (player == null) return;

        float mouseX = 0f;
        float mouseY = 0f;

        if (Input.GetMouseButton(1))
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
        }

        if (invertY)
            currentY += mouseY * mouseSensitivity;
        else
            currentY -= mouseY * mouseSensitivity;

        currentX += mouseX * mouseSensitivity;
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = player.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        Vector3 lookTarget = player.position + Vector3.up * 1.5f;
        Quaternion desiredRotation = Quaternion.LookRotation(lookTarget - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothSpeed * Time.deltaTime);
    }
}

