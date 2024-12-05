using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public float slowness = 10f;
    public TMP_Text gameOverText; // Riferimento alla scritta Game Over
    public TMP_Text winText;      // Riferimento alla scritta Win
    public int wavesToWin = 5;    // Numero di onde per vincere

    private int currentWave = 0;

    public void IncrementWave()
    {
        currentWave++;
        if (currentWave >= wavesToWin)
        {
            WinGame();
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        gameOverText.gameObject.SetActive(true); // Mostra la scritta preimpostata
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        winText.gameObject.SetActive(true); // Mostra la scritta preimpostata
    }
}
