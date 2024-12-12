using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlaneGameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject Attempt1;
    public GameObject Attempt2;
    public GameObject Attempt3;
    public GameObject victoryText; // Victory text
    private static int attempts = 0; // Number of attempts made
    private const int maxAttempts = 3; // Maximum number of allowed games
    public float winTime = 30f; // Tempo per vincere (modificabile nell'Inspector)

    private bool isGameOver = false;
    private bool isWin = false;
    private float elapsedTime = 0f; // Tempo trascorso

    void Update()
    {
        if (!isGameOver && !isWin)
        {
            elapsedTime += Time.deltaTime;

            // Controlla se è stato raggiunto il tempo per vincere
            if (elapsedTime >= winTime)
            {
                ShowVictory();
            }
        }
    }

    private void Start()
    {
        Debug.Log("Game started!");
        ShowAttemptText(); // Show the current attempt text
    }

    public void ShowGameOver()
    {
        if (!isGameOver && !isWin)
        {
            if (gameOverText != null)
            {
                gameOverText.SetActive(true); // Show Game Over text
            }

            // Check if the player still has games available
            if (attempts < maxAttempts)
            {
                Debug.Log("Restarting game in 2 seconds...");
                isGameOver = true;
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
        if (!isGameOver)
        {
            isGameOver = true;
            if (victoryText != null)
            {
                victoryText.SetActive(true); // Show victory text
            }
            Time.timeScale = 0; // Stop the game time
            Debug.Log("Victory!");
        }
    }

    private void CheckVictory()
    {
        // Example method: check victory conditions
        if (!isGameOver)
        {
            ShowVictory();
            SceneManager.LoadScene("Davide4Car");
        }
    }

    // Method to show the correct attempt text
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
