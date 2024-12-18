using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMaze : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject Attempt1;
    public GameObject Attempt2;
    public GameObject Attempt3;
    public GameObject victoryText; 
    private bool gameEnded = false;
    private static int attempts = 0; 
    private const int maxAttempts = 3; 
    public int keys = 0;
    public float speed = 5.0f;
    private static int setmood = 0; 
    private static int setsigarette = 1;

    public Text keyAmount;
    public GameObject door;

  
    private void Start()
    {
        Debug.Log("Game started!");
        ShowAttemptText(); // Show the current attempt text
        victoryText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        if (keys == 3)
        {
            Destroy(door);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Keys")
        {
            keys++;
            keyAmount.text = "Keys: " + keys;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Flag")
        {
            victoryText.gameObject.SetActive(true);
            Time.timeScale = 3;
            SceneManager.LoadScene("Davide5Won");
        }

        if (collision.gameObject.tag == "Enemies")
        {
            if (gameOverText != null)
            {
                gameOverText.SetActive(true); 
            }

            if (attempts < maxAttempts)
            {
                Debug.Log("Restarting game in 2 seconds...");
                gameEnded = true;
                attempts++;
                Debug.Log($"Game over. Attempts: {attempts}/{maxAttempts}");

                // Show the current attempt text
                ShowAttemptText();

                // Reload the scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (attempts == maxAttempts)
            {
                Debug.Log("You have reached the maximum number of games. Game over.");
                SceneManager.LoadScene("Davide5Lost");
                if (gameOverText != null)
                {
                    gameOverText.SetActive(true);
                }
            }
        }
    }
    private void ShowAttemptText()
    {
        switch (attempts)
        {
            case 0:
                Attempt1.SetActive(true);
                break;
            case 1:
                Attempt2.SetActive(true);
                break;
            case 2:
                Attempt3.SetActive(true);
                break;
            default:
                // If attempts >= 3, no more attempts are shown
                break;
        }
    }
}