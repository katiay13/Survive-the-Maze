using UnityEngine;
using TMPro;
using System.Collections;

// Displays temporary notification messages on screen
public class UINotification : MonoBehaviour
{
    public static UINotification instance; // singleton for global access

    public GameObject notificationPanel;
    public TMP_Text notificationText;
    private Animator animator;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        animator = notificationPanel.GetComponent<Animator>();
        notificationPanel.SetActive(false); // hide panel on startup
    }

    // Cancels any active notification and shows a new one
    public void ShowNotification(string message, Color color)
    {
        StopAllCoroutines();
        StartCoroutine(NotificationCoroutine(message, color));
    }

    // Shows the notification, waits 2 seconds, then hides it
    private IEnumerator NotificationCoroutine(string message, Color color)
    {
        notificationText.text = message;
        notificationText.color = color;
        notificationPanel.SetActive(true);
        animator.Play("NotificationSlideIn");
        yield return new WaitForSeconds(2f);
        notificationPanel.SetActive(false);
    }
}