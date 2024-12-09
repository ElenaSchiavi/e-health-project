using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab; // Prefab dei tubi
    public float spawnRate = 2f; // Frequenza di spawn (in secondi)
    public float heightOffset = 2f; // Offset verticale dei tubi

    private void Start()
    {
        
        if (pipePrefab == null)
        {
            Debug.LogError("Pipe Prefab non è stato assegnato!");
        }
        else
        {
            Debug.Log("Pipe Prefab assegnato correttamente!");
        }


    // Inizia a generare i tubi periodicamente
    InvokeRepeating("SpawnPipe", 1f, spawnRate);

    }

    void SpawnPipe()
    {
        if(pipePrefab == null)
    {
            Debug.LogError("pipePrefab non è stato assegnato!");
            return;
        }

        // Genera un PipePair con un'altezza casuale
        float randomY = Random.Range(-heightOffset, heightOffset);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}
