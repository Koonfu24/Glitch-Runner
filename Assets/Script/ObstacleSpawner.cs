using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform spawnPoint;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    private float timer;
    private float currentSpawnTime;

    void Start()
    {
        SetRandomTime();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= currentSpawnTime)
        {
            SpawnObstacle();
            timer = 0;
            SetRandomTime();
        }
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
    }

    void SetRandomTime()
    {
        currentSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
