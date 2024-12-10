using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeGame : MonoBehaviour
{
    public void Resume()
    {
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        string lastScene = PlayerPrefs.GetString("LastScene", "");

        if (!string.IsNullOrEmpty(lastScene))
        {
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            Debug.Log("No saved scene found.");
        }
    }
}