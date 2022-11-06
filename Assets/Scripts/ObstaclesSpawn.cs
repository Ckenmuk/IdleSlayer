using System;
using UnityEngine;

public class ObstaclesSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] coins;
    [SerializeField] private GameObject[] bonuses;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    public float enemiesSpawnFrequency = 0.5f;
    public float coinsSpawnFrequency = 2.0f;
    public float bonusesSpawnFrequency = 10.0f;
    private float enemySpawnTime;
    private float coinsSpawnTime;
    private float bonusesSpawnTime;


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
        if (Time.time > bonusesSpawnTime)
        {
            Spawn(bonuses);
            bonusesSpawnTime = Time.time + bonusesSpawnFrequency;
        }
    }

    private void Spawn(GameObject[] spawnObject)
    {
        float randomX = UnityEngine.Random.Range(minX, maxX);
        float randomY = UnityEngine.Random.Range(minY, maxY);

        int randomObject = 0;

        
        for (int j = spawnObject.Length; j >= 0; j--)
        {
            if (UnityEngine.Random.Range(0, (float)Math.Pow(10, j)) < 5)
            {
                randomObject = j;
                break;
            }
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
