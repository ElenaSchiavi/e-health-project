using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 direction = Vector3.left;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        
        if (transform.position.y < -10f || transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }
}