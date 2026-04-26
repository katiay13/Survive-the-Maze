using UnityEngine;

public class MazeExit : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // If player touches exit then show win screen
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.CheckAndSaveHighScore();
            WinManager.instance.ShowWinScreen();
        }
    }
}