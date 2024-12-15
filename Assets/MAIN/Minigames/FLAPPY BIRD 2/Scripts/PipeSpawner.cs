using UnityEngine;

public class PipeSpawner1 : MonoBehaviour
{
    public GameObject pipePrefab;
    public static float spawnRate = 0.8f;
    public float heightOffset = 2f;

    private void Start()
    {
        
        if (pipePrefab == null)
        {
            Debug.LogError("Pipe Prefab non � stato assegnato!");
        }
        else
        {
            Debug.Log("Pipe Prefab assegnato correttamente!");
        }
        
    InvokeRepeating("SpawnPipe", 1f, spawnRate);

    }

    void SpawnPipe()
    {
        if(pipePrefab == null)
    {
            Debug.LogError("pipePrefab non � stato assegnato!");
            return;
        }
        
        float randomY = Random.Range(-heightOffset, heightOffset);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}