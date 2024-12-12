using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DodgeGameManager : MonoBehaviour
{

    public float slowness = 10f;
    public GameObject gameOverText; // Riferimento alla scritta Game Over
    public GameObject winText;      // Riferimento alla scritta Win
    public GameObject Attempt1;
    public GameObject Attempt2;
    public GameObject Attempt3;
    public int wavesToWin = 5;    // Numero di onde per vincere
    private bool gameEnded = false;
    private static int attempts = 0; // Number of attempts made
    private const int maxAttempts = 3; // Maximum number of allowed games

    private int currentWave = 0;

    public void IncrementWave()
    {
        currentWave++;
        if (currentWave >= wavesToWin)
        {
            WinGame();
        }
    }
        private void Start()
    {
        Debug.Log("Game started!");
        ShowAttemptText(); // Show the current attempt text
        winText.gameObject.SetActive(false);
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

    public void WinGame()
    {
        Time.timeScale = 0f;
        winText.gameObject.SetActive(true); // Mostra la scritta preimpostata
        SceneManager.LoadScene("Davide4Car");
    }

    private void ShowAttemptText()
    {
        // Enable the correct attempt text based on the number of attempts
        switch (attempts)
        {
            case 0:
                Attempt1.SetActive(true);
                break;
            case 1:
                Attempt2.SetActive(true);
                break;
            case 2:
                Attempt3.SetActive(true);
                break;
            default:
                // If attempts >= 3, no more attempts are shown
                break;
        }
    }
}
