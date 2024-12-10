using UnityEngine;
using UnityEngine.SceneManagement; // Necessario per il cambio scena

public class SceneSwitcher_Space : MonoBehaviour
{
    [SerializeField] private string sceneName; // Nome della scena da caricare

    void Update()
    {
        // Controlla se è stata premuta la barra spaziatrice
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
