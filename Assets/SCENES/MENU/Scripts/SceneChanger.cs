using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextSceneName;  // Nome della scena successiva
    public float delay = 5f;      // Tempo in secondi prima del cambio

    void Start()
    {
        // Avvia il cambio scena dopo un determinato ritardo
        Invoke("ChangeScene", delay);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}