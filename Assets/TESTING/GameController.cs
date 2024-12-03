using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;

    void Start()
    {
        bottomBar.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Input received.");

            if (bottomBar.IsCompleted())
            {
                if (bottomBar.IsLastSentence())
                {
                    Debug.Log("Loading next scene.");
                    currentScene = currentScene.nextScene;

                    if (currentScene != null)
                    {
                        bottomBar.PlayScene(currentScene);
                        backgroundController.SwitchImage(currentScene.background);
                    }
                    else
                    {
                        Debug.LogWarning("No next scene available.");
                    }
                }
                else
                {
                    bottomBar.PlayNextSentence();
                }
            }
        }
    }
}
