using UnityEngine;

// Triggers the win screen when the player reaches the maze exit
public class MazeExit : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Save high score and show win screen when player touches the exit
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.CheckAndSaveHighScore();
            WinManager.instance.ShowWinScreen();
        }
    }
}