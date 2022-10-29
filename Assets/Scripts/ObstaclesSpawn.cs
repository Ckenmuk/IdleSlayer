using UnityEngine;

public class ObstaclesSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] coins;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float enemiesSpawnFrequency;
    [SerializeField] private float coinsSpawnFrequency;
    private float enemySpawnTime;
    private float coinsSpawnTime;


    private void Update()
    {
        Timer();
        
    }

    private void Timer()
    {
        if (Time.time > enemySpawnTime)
        {
            Spawn(enemies);
            enemySpawnTime = Time.time + enemiesSpawnFrequency;
        }
        if (Time.time > coinsSpawnTime)
        {
            Spawn(coins);
            coinsSpawnTime = Time.time + coinsSpawnFrequency;
        }
    }

    private void Spawn(GameObject[] spawnObject)
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        int randomObject;

        if (Random.Range(0, 1000) < 10)
        {
            randomObject = 2;
        }
        else if (Random.Range(0, 100) < 10)
        {
            randomObject = 1;
        }
        else
        {
            randomObject = 0;
        }

        Instantiate(spawnObject[randomObject], transform.position + new Vector3(randomX, randomY, 0.0f), transform.rotation);

        if (randomX > 0)
        {
            spawnObject[randomObject].transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
        }
        else
        {
            spawnObject[randomObject].transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }

    }
}
