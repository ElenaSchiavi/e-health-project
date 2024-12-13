using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject blockPrefab;
    public float timeBetweenWaves = 1f;
    private float timeToSpawn = 2f;
    private GameManager gameManager;

    private int activeBlocks = 0;

    void Update()
    {
        if (activeBlocks == 0 && Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
            Object.FindAnyObjectByType<DodgeGameManager>().IncrementWave();
        }
    }

    void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
                activeBlocks++;
            }
        }
    }

    public void BlockDestroyed()
    {
        activeBlocks--;
    }
}