using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeGame: MonoBehaviour
{
    public void Resume()
    {
        

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