using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Attempt1;
    public GameObject Attempt2;
    public GameObject Attempt3;
    public float slowness = 10f;
    public GameObject gameOverText; // Riferimento alla scritta Game Over
    public GameObject WinTxt;      // Riferimento alla scritta Win
    public int wavesToWin = 5;    // Numero di onde per vincere
    private static int attempts = 0; // Number of attempts made
    private const int maxAttempts = 3; // Maximum number of allowed games
    private bool gameEnded = false;
    private int currentWave = 0;

    public void IncrementWave()
    {
        currentWave++;
        if (currentWave >= wavesToWin)
        {
            ShowVictory();
        }
    }

    public void ShowGameOver()
    {
        if (!gameEnded)
        {
            if (gameOverText != null)
            {
                gameOverText.SetActive(true); // Show Game Over text
            }

            // Check if the player still has games available
            if (attempts < maxAttempts)
            {
                Debug.Log("Restarting game in 2 seconds...");
                gameEnded = true;
                attempts++;
                Debug.Log($"Game over. Attempts: {attempts}/{maxAttempts}");

                // Show the current attempt text
                ShowAttemptText();  

                // Reload the scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (attempts == maxAttempts)
            {
                Debug.Log("You have reached the maximum number of games. Game over.");
                SceneManager.LoadScene("Davide4Car");
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
            WinTxt.SetActive(true); // Show victory text
            Time.timeScale = 0; // Stop the game time
            Debug.Log("Victory!");
            SceneManager.LoadScene("Davide4Car");
        }
    }

    // Method to show the correct attempt text
    private void ShowAttemptText()
    {
        // Enable the correct attempt text based on the number of attempts
        switch (attempts)
        {
            case 1:
                Attempt1.SetActive(true);
                break;
            case 2:
                Attempt2.SetActive(true);
                break;
            case 3:
                Attempt3.SetActive(true);
                break;
            default:
                // If attempts >= 3, no more attempts are shown
                break;
        }
    }
}


