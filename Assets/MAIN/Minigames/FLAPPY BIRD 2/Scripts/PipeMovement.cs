using UnityEngine;

public class PipeMovement1 : MonoBehaviour
{
    public static float speed = 10f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}