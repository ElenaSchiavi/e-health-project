using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DodgeGameManager : MonoBehaviour
{

    public float slowness = 10f;
    public GameObject gameOverText;
    public GameObject winText;
    public GameObject Attempt1;
    public GameObject Attempt2;
    public GameObject Attempt3;
    public int wavesToWin = 0;
    private bool gameEnded = false;
    private static int attempts = 0;
    private const int maxAttempts = 3;
    private static int setmood = 0;
    private static int setsigarette = 1;

    private int currentWave = 0;


    private void Start()
    {
        Debug.Log("Loading Sigarette Number from YarnCSLoader");
        int sigaretteFumate = YarnCSLoader.getSigarette();
        Debug.Log($"Finora fumate {sigaretteFumate} sigarette");
        Debug.Log("Loading Mood from YarnCSLoader");
        int mood = YarnCSLoader.getMood();
        Debug.Log($"Mood attuale {mood}");

        if (sigaretteFumate >= setsigarette && mood < setmood) wavesToWin = 20;
        if (sigaretteFumate >= setsigarette && mood >= setmood) wavesToWin = 12;
        if (sigaretteFumate < setsigarette && mood < setmood) wavesToWin = 12;
        if (sigaretteFumate < setsigarette && mood >= setmood) wavesToWin = 5;

        Debug.Log("Game started!");
        ShowAttemptText();
        winText.gameObject.SetActive(false);
    }
    public void IncrementWave()
    {
        currentWave++;
        if (currentWave >= wavesToWin)
        {
            WinGame();
        }
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
                SceneManager.LoadScene("Davide10Lost");
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
        winText.gameObject.SetActive(true);
        SceneManager.LoadScene("Davide10Won");
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