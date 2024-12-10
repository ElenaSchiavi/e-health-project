using UnityEngine;

public class ObstacleSpawnerTop : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array di prefab da cui scegliere
    public float spawnRate = 2f; // Intervallo di tempo tra uno spawn e l'altro
    public float spawnXRange = 10f; // Intervallo orizzontale per spawn casuale

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
        float spawnX = Random.Range(-spawnXRange, spawnXRange); // Posizione X casuale
        float spawnY = 5f; // Posizione fissa in alto
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        // Scegli un prefab casuale
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedPrefab = obstaclePrefabs[randomIndex];

        // Instanzia il prefab
        GameObject obstacle = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

        // Imposta la direzione per farlo scendere dall'alto
        ObstacleMovement movement = obstacle.GetComponent<ObstacleMovement>();
        if (movement != null)
        {
            movement.direction = Vector3.down; // Cambia la direzione a "giù"
        }
    }

}
