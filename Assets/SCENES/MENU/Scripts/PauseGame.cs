using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public void Pause()
    {
        string savedScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SavedScene", savedScene);
        SceneManager.LoadScene("Menu_4");
    }
}