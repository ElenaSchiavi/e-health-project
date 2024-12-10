using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f; // Velocità del movimento
    public Vector3 direction = Vector3.left; // Direzione predefinita: a sinistra

    void Update()
    {
        // Muovi l'ostacolo nella direzione impostata
        transform.position += direction * speed * Time.deltaTime;

        // Distruggi l'ostacolo quando esce dallo schermo
        if (transform.position.y < -10f || transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }
}
