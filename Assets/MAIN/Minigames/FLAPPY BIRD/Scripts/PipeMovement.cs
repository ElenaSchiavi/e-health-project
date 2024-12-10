using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 4f; // Velocità del movimento

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
