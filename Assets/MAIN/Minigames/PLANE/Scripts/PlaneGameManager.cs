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
    public float winTime = 0f;
    private static int setmood = 0; 
    private static int setsigarette = 1;

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
        Debug.Log("Loading Sigarette Number from YarnCSLoader");
        int sigaretteFumate = YarnCSLoader.getSigarette();
        Debug.Log($"Finora fumate {sigaretteFumate} sigarette");
        Debug.Log("Loading Mood from YarnCSLoader");
        int mood = YarnCSLoader.getMood();
        Debug.Log($"Mood attuale {mood}");

        if (sigaretteFumate >= setsigarette && mood < setmood) winTime = 60f;
        if (sigaretteFumate >= setsigarette && mood >= setmood) winTime = 30f;
        if (sigaretteFumate < setsigarette && mood < setmood) winTime = 30f;
        if (sigaretteFumate < setsigarette && mood >= setmood) winTime = 15f;

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
                SceneManager.LoadScene("Davide4Car");
            }
            Time.timeScale = 0;
            Debug.Log("Victory!");
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