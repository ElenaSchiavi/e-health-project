using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlaneGameManager : MonoBehaviour
{
    public GameObject gameOverText; // Oggetto UI per "Game Over"
    public GameObject winText; // Oggetto UI per "Win"
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
                WinGame();
            }
        }
    }

    public void EndGame()
    {
        if (!isGameOver && !isWin)
        {
            isGameOver = true;
            Debug.Log("Game Over!");
            StartCoroutine(GameOverSequence());
        }
    }

    private void WinGame()
    {
        isWin = true;
        Debug.Log("You Win!");
        StartCoroutine(WinSequence());
    }

    private IEnumerator GameOverSequence()
    {
        gameOverText.SetActive(true); // Mostra il testo "Game Over"
        yield return new WaitForSeconds(1f); // Aspetta 1 secondo
        Time.timeScale = 0f; // Ferma il gioco
    }

    private IEnumerator WinSequence()
    {
        winText.SetActive(true); // Mostra il testo "Win"
        yield return new WaitForSeconds(1f); // Aspetta 1 secondo
        Time.timeScale = 0f; // Ferma il gioco
    }
}
