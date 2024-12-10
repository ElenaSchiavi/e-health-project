using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeGame : MonoBehaviour
{
	if (PlayerPrefs.HasKey("SavedScene"))
    {
		string savedScene = PlayerPrefs.GetString("SavedScene");
        SceneManager.LoadScene(savedScene);
    }
    else
    {
		Debug.LogWarning("No saved scene found!");
	}
}