using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;

    public float spawnInterval = 1.5f;
    public float distanceX = 10f;

    public float topY = 1.5f;
    public float bottomY = -1.5f;

    public int blocksPerSide = 3; // จำนวนบล็อคต่อฝั่ง

    private float timer;
    private float nextSpawnX;
    private bool spawnTop = true;
    private int blockCount = 0;

    void Start()
    {
        nextSpawnX = transform.position.x;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnGround();
            timer = 0f;
        }
    }

    void SpawnGround()
    {
        float yPos = spawnTop ? topY : bottomY;

        Vector3 spawnPos = new Vector3(nextSpawnX, yPos, 0f);
        Instantiate(groundPrefab, spawnPos, Quaternion.identity);

        nextSpawnX += distanceX;

        blockCount++;

        // ครบจำนวนบล็อคแล้วค่อยสลับฝั่ง
        if (blockCount >= blocksPerSide)
        {
            spawnTop = !spawnTop;
            blockCount = 0;
        }
    }
}
