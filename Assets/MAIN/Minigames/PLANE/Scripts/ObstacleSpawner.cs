using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array di prefabs degli ostacoli

    public float spawnRate = 1.5f; // Tempo tra uno spawn e l'altro
    public float spawnYRange = 4f; // Intervallo verticale per generare ostacoli

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float spawnX = 10f; // Posizione fissa sul lato destro
        float spawnY = Random.Range(-spawnYRange, spawnYRange); // Posizione Y casuale
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        // Scegli un prefab casuale dall'array
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedPrefab = obstaclePrefabs[randomIndex];

        // Instanzia il prefab
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}
