using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawn : MonoBehaviour
{
    [SerializeField] private List<UnityEngine.Object> enemies;
    [SerializeField] private List<UnityEngine.Object> coins;
    [SerializeField] private List<UnityEngine.Object> bonuses;
    
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private bool enemiesOn;
    private bool bonusesOn;

    public float coinsSpawnDelay = 2.0f;
    public float enemiesSpawnDelay = 5.0f;
    public float bonusesSpawnDelay = 30.0f;

    private float enemySpawnTime;
    private float coinsSpawnTime;
    private float bonusesSpawnTime;
    
    public void EnemiesOn()
    {
        enemiesOn = true;
    }

    public void BonusesOn()
    {
        bonusesOn = true;
        bonuses.Add(Resources.Load("Prefab/Chest"));
    }

    public void InvulnerabilityOn()
    {
        bonuses.Add(Resources.Load("Prefab/Invulnerability"));
    }

    public void SilverCoinsOn()
    {
        if(coins.Count < 2)
        {
            coins.Add(Resources.Load("Prefab/SilverCoin"));
        }
    }

    public void GoldCoinsOn()
    {
        if (coins.Count > 1 && coins.Count < 3)
        {
            coins.Add(Resources.Load("Prefab/GoldCoin"));
        }
    }

    public void BossesOn()
    {
        if (enemies.Count < 2)
        {
            enemies.Add(Resources.Load("Prefab/Enemy Boss"));
            enemies.Add(Resources.Load("Prefab/Sword"));
            enemies.Add(Resources.Load("Prefab/Meteor"));
        }
    }

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        if (enemiesOn && Time.time > enemySpawnTime)
        {
            Spawn(enemies);
            enemySpawnTime = Time.time + enemiesSpawnDelay;
        }
        if (Time.time > coinsSpawnTime)
        {
            Spawn(coins);
            coinsSpawnTime = Time.time + coinsSpawnDelay;
        }
        if (bonusesOn && Time.time > bonusesSpawnTime)
        {
            Spawn(bonuses);
            bonusesSpawnTime = Time.time + bonusesSpawnDelay;
        }
    }

    private void Spawn(List<UnityEngine.Object> spawnObject)
    {
        float randomX = UnityEngine.Random.Range(minX, maxX);
        float randomY = UnityEngine.Random.Range(minY, maxY);

        int randomObject = 0;

        
        for (int j = spawnObject.Count; j >= 0; j--)
        {
            if (UnityEngine.Random.Range(0, (float)Math.Pow(10, j)) < 5)
            {
                randomObject = j;
                break;
            }
        }

        Instantiate(spawnObject[randomObject], transform.position + new Vector3(randomX, randomY, 0.0f), transform.rotation, GameObject.Find("GameManager").transform);

    }

    
}
