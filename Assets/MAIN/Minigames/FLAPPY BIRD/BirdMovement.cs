using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float jumpForce = 3f; // Forza del salto
    private Rigidbody2D rb;
    private bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * jumpForce; // Applica una forza verso l'alto
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            isGameOver = true;
            Debug.Log("Game Over!");
            // Blocca il movimento del Bird
            rb.linearVelocity = Vector2.zero;
            rb.isKinematic = true;

            // Mostra la scritta Game Over
            FindObjectOfType<GameManager>().ShowGameOver();
            Invoke("StopGame", 1f); // Ferma il gioco dopo 2 secondi
        }
    }

    void StopGame()
    {
        Time.timeScale = 0; // Ferma il tempo di gioco
    }
}
