using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    public float spawnRate = 1.5f;
    public float spawnYRange = 4f;

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
        float spawnX = 10f;
        float spawnY = Random.Range(-spawnYRange, spawnYRange);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);
        
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedPrefab = obstaclePrefabs[randomIndex];
        
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}