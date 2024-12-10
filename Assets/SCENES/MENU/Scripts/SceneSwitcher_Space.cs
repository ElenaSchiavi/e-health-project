using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher_Space : MonoBehaviour
{
    [SerializeField] private string sceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
