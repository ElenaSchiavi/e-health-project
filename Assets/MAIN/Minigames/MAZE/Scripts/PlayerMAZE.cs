﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMaze : MonoBehaviour
{
    public int keys = 0;
    public float speed = 5.0f;

    public GameObject Attempt1;
    public GameObject Attempt2;
    public GameObject Attempt3;
    public GameObject gameOverText; // Riferimento alla scritta Game Over
    public GameObject WinTxt;      // Riferimento alla scritta Win
    private static int attempts = 0; // Number of attempts made
    private const int maxAttempts = 3; // Maximum number of allowed games
    private bool gameEnded = false;


    public Text keyAmount;
    public GameObject door;

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

        if (collision.gameObject.tag == "Princess")
        {
            gameEnded = true;
            WinTxt.SetActive(true); // Show victory text
            Time.timeScale = 0; // Stop the game time
            Debug.Log("Victory!");
            SceneManager.LoadScene("Davide4Car");
        }

        if (collision.gameObject.tag == "Enemies")
        {
            if (!gameEnded)
            {
                if (gameOverText != null)
                {
                    gameOverText.SetActive(true); // Show Game Over text
                }

                // Check if the player still has games available
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
                    SceneManager.LoadScene("Davide4Car");
                    if (gameOverText != null)
                    {
                        gameOverText.SetActive(true);
                    }
                }
            }
        }
    }
    private void ShowAttemptText()
    {
        // Enable the correct attempt text based on the number of attempts
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