using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float jumpForce = 3f;
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
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            isGameOver = true;
            Debug.Log("Game Over!");
            rb.linearVelocity = Vector2.zero;
            rb.isKinematic = true;
            
            FindObjectOfType<GameManager1>().ShowGameOver();
            Invoke("StopGame", 1f); 
        }
    }

    void StopGame()
    {
        Time.timeScale = 0;
    }
}