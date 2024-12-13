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
    public GameObject victoryText;
    private static int attempts = 0;
    private const int maxAttempts = 3;
    public float winTime = 30f;

    private bool isGameOver = false;
    private bool isWin = false;
    private float elapsedTime = 0f;

    void Update()
    {
        if (!isGameOver && !isWin)
        {
            elapsedTime += Time.deltaTime;
            
            if (elapsedTime >= winTime)
            {
                ShowVictory();
            }
        }
    }

    private void Start()
    {
        Debug.Log("Game started!");
        ShowAttemptText();
    }

    public void ShowGameOver()
    {
        if (!isGameOver && !isWin)
        {
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }
            
            if (attempts < maxAttempts)
            {
                Debug.Log("Restarting game in 2 seconds...");
                isGameOver = true;
                attempts++;
                Debug.Log($"Game over. Attempts: {attempts}/{maxAttempts}");
                
                ShowAttemptText();
                
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
                victoryText.SetActive(true);
            }
            Time.timeScale = 0;
            Debug.Log("Victory!");
        }
    }

    private void CheckVictory()
    {
        if (!isGameOver)
        {
            ShowVictory();
            SceneManager.LoadScene("Davide4Car");
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