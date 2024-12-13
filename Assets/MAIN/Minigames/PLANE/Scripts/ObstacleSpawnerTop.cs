using UnityEngine;

public class ObstacleSpawnerTop : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnRate = 2f;
    public float spawnXRange = 10f;

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
        float spawnX = Random.Range(-spawnXRange, spawnXRange);
        float spawnY = 5f;
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);
        
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedPrefab = obstaclePrefabs[randomIndex];
        
        GameObject obstacle = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        
        ObstacleMovement movement = obstacle.GetComponent<ObstacleMovement>();
        if (movement != null)
        {
            movement.direction = Vector3.down;
        }
    }
}