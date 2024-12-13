using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject m_MainMenuPanel;
    public GameObject m_GameMenuPanel;
    public GameObject m_GameOverPanel;
    public GameObject m_Scores;
    public GameObject gameOverText; // Riferimento alla scritta Game Over
    public GameObject winText;      // Riferimento alla scritta Win
    public Text m_GameOverFinalScore;

    public enum GameState { MainMenu, Playable, GameOver, }
    private GameState m_State = GameState.MainMenu;

    public GameState m_GameState
    {
        set
        {
            m_State = value;

            switch (value)
            {
                case GameState.MainMenu:
                    m_MainMenuPanel.SetActive(true);
                    m_GameMenuPanel.SetActive(false);
                    m_GameOverPanel.SetActive(false);
                    m_Scores.SetActive(true);

                    BallLauncher.Instance.OnMainMenuActions();
                    BrickSpawner.Instance.HideAllBricksRows();
                    break;
                case GameState.Playable:
                    if (Saver.Instance.HasSave())
                    {

                    }
                    else
                    {
                        m_MainMenuPanel.SetActive(false);
                        m_GameMenuPanel.SetActive(true);
                        m_GameOverPanel.SetActive(false);
                        m_Scores.SetActive(true);

                        BallLauncher.Instance.m_CanPlay = true;
                        BrickSpawner.Instance.m_LevelOfFinalBrick = 1;  // temporary (after save and load)

                        // reset score (probably by conditions)
                        ScoreManager.Instance.m_ScoreText.text = BrickSpawner.Instance.m_LevelOfFinalBrick.ToString();

                        BrickSpawner.Instance.SpawnNewBricks();
                    }
                    break;
                case GameState.GameOver:
                    m_MainMenuPanel.SetActive(false);
                    m_GameMenuPanel.SetActive(false);
                    m_GameOverPanel.SetActive(true);
                    m_Scores.SetActive(false);

                    int finalScore = BrickSpawner.Instance.m_LevelOfFinalBrick - 1;

                    if (finalScore >= 20)
                    {
                        // Load the "Good job!" scene
                        winText.gameObject.SetActive(true); 
                        SceneManager.LoadScene("Davide8Win");
                    }
                    else
                    {
                        // Load the "Game over!" scene
                        gameOverText.SetActive(true);
                        SceneManager.LoadScene("Davide8Lost");
                    }

                    m_GameOverFinalScore.text = "Final Score : " + finalScore.ToString();
                    BallLauncher.Instance.m_CanPlay = false;
                    BallLauncher.Instance.ResetPositions();
                    break;
            }
        }
        get
        {
            return m_State;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        m_GameState = GameState.MainMenu;
    }
}
