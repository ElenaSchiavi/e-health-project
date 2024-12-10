using UnityEngine;
using System.Collections;


public class PlaneMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocità di movimento
    public float rotationSpeed = 5f; // Velocità di rotazione per un movimento fluido
    public float tiltAmount = 50f; // Grado di inclinazione per simulare il volo
    public float moveLimitX = 10f; // Limite del movimento sull'asse X
    public float moveLimitY = 4f; // Limite del movimento sull'asse Y

    private PlaneGameManager gameManager;

    void Start()
    {
        // Trova il GameManager nella scena
        gameManager = FindObjectOfType<PlaneGameManager>();
    }

    void Update()
    {
        // Ottieni la posizione del mouse nel mondo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Mantieni il piano 2D

        // Calcola la direzione verso cui muovere il Plane
        Vector3 direction = mousePosition - transform.position;

        // Muovi il Plane verso il mouse
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

        // Limita il movimento entro i confini della scena
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -moveLimitX, moveLimitX),
            Mathf.Clamp(transform.position.y, -moveLimitY, moveLimitY),
            0
        );

        // Calcola l'angolo di rotazione
        float tilt = Mathf.Clamp(-direction.x * tiltAmount, -tiltAmount, tiltAmount); // Inclinazione laterale basata sull'asse X
        Quaternion targetRotation = Quaternion.Euler(0, 0, tilt);

        // Applica la rotazione gradualmente per renderla fluida
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Controlla se la collisione è con un ostacolo
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Termina il gioco
            gameManager.EndGame();
        }
    }
}
