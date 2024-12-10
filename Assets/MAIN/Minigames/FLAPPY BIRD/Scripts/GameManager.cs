using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject victoryText; // Testo di vittoria
    private bool gameEnded = false;

    private void Start()
    {
        Invoke("CheckVictory", 20f); // Controlla la vittoria dopo 30 secondi
    }

    public void ShowGameOver()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
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
            Time.timeScale = 0; // Ferma il tempo di gioco
        }
    }

    private void CheckVictory()
    {
        if (!gameEnded)
        {
            ShowVictory(); // Mostra il messaggio di vittoria se il gioco non � terminato
        }
    }
}
