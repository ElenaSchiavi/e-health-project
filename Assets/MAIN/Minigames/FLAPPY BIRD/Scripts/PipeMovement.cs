using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public static float speed = 10f; // Velocità del movimento

    void Update()
    {
        // Muove il PipePair verso sinistra
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Distrugge l'oggetto se esce dallo schermo
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
