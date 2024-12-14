using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject Attempt1;
    public GameObject Attempt2;
    public GameObject Attempt3;
    public GameObject victoryText;
    private bool gameEnded = false;
    private static int attempts = 0;
    private const int maxAttempts = 3;
    private float gameWinTime=90f;
    private void Start()
    {
        Debug.Log("Loading Sigarette Number from YarnCSLoader");
        int sigaretteFumate=YarnCSLoader.getSigarette();
        Debug.Log($"Finora fumate {sigaretteFumate} sigarette");

        if(sigaretteFumate>=1)gameWinTime=40f;
        else gameWinTime=5f;
        Debug.Log("Game started!");
        Invoke("CheckVictory", gameWinTime);
        ShowAttemptText();
    }

    public void ShowGameOver()
    {
        if (!gameEnded)
        {
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }
            
            if (attempts < maxAttempts)
            {
                Debug.Log("Restarting game in 2 seconds...");
                gameEnded = true;
                attempts++;
                Debug.Log($"Game over. Attempts: {attempts}/{maxAttempts}");
                
                ShowAttemptText();
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (attempts == maxAttempts)
            {
                Debug.Log("You have reached the maximum number of games. Game over.");
                SceneManager.LoadScene("Davide3Lost");
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
            Time.timeScale = 0;
            Debug.Log("Victory!");
        }
    }

    private void CheckVictory()
    {
        if (!gameEnded)
        {
            ShowVictory();
            SceneManager.LoadScene("Davide3Win");
        }
    }
    
    private void ShowAttemptText()
    {
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
                break;
        }
    }
}