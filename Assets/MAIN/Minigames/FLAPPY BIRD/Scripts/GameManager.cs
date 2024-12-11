using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject victoryText; // Victory text
    private bool gameEnded = false;
    private static int attempts = 0; // Number of attempts made
    private const int maxAttempts = 3; // Maximum number of allowed games

    private void Start()
    {
        Debug.Log("Game started!");
        Invoke("CheckVictory", 20f); // Check for victory after 20 seconds
    }

    public void ShowGameOver()
    {
        if (!gameEnded)
        {           
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }

            // Check if the player still has games available
            if (attempts < maxAttempts - 1)
            {
                Debug.Log("Restarting game in 2 seconds...");
                gameEnded = true;
                attempts++;
                Debug.Log($"Game over. Attempts: {attempts + 1}/{maxAttempts}");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (attempts == maxAttempts - 1)
            {
                Debug.Log("You have reached the maximum number of games. Game over.");
                SceneManager.LoadScene("Davide5Workplace");
                if (gameOverText != null)
                {
                    gameOverText.SetActive(true);
                }
            }
        }
    }

    public void ShowVictory()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            if (victoryText != null)
            {
                victoryText.SetActive(true);
            }
            Time.timeScale = 0; // Stop the game time
            Debug.Log("Victory!");
        }
    }
    private void CheckVictory()
    {
        // Example method: check victory conditions
        if (!gameEnded)
        {
            ShowVictory();
            SceneManager.LoadScene("Davide5Workplace");
        }
    }
}
