using UnityEngine;
using UnityEngine.SceneManagement; // Necessario per il cambio scena

public class SceneSwitcher_Button : MonoBehaviour
{
    [SerializeField] private string sceneName; // Nome della scena da caricare

    // Metodo chiamabile dal bottone
    public void LoadScene()
    {
            SceneManager.LoadScene(sceneName);
    }
}

