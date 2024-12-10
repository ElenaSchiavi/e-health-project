using UnityEngine;

public class Block : MonoBehaviour
{

    private BlockSpawner blockSpawner;

    void Start()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 20f;
    }

    void Update()
    {
        if (transform.position.y < -2f)
        {
            DestroyBlock();
        }
    }

    void DestroyBlock()
    {
        blockSpawner.BlockDestroyed(); // Notifica al BlockSpawner
        Destroy(gameObject);
    }
}
