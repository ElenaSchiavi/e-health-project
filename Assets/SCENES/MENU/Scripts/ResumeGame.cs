using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeGame : MonoBehaviour
{
	public void Resume()
	{
		if (PlayerPrefs.HasKey("SavedScene"))
		{
			string savedScene = PlayerPrefs.GetString("SavedScene");
			SceneManager.LoadScene(savedScene);
		}
	}
}