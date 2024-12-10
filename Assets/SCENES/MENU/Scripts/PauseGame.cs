using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame: MonoBehaviour
{   
    public void Pause()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SavedScene", currentScene);
        SceneManager.LoadScene("Menu_4");
    }
}