using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawn : MonoBehaviour
{
    private Settings settings;
    private ImproveManager improveManager;

    [SerializeField] private List<UnityEngine.Object> enemies;
    [SerializeField] private List<UnityEngine.Object> coins;
    [SerializeField] private List<UnityEngine.Object> bonuses;
    
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private bool enemiesOn;
    private bool silverCoinsOn;
    private bool goldCoinsOn;
    private bool bossesOn;
    private bool invulnerabilityOn;
    private bool bonusesOn;


    public float coinsSpawnDelay = 2.0f;
    public float enemiesSpawnDelay = 5.0f;
    public float bonusesSpawnDelay = 30.0f;

    private float enemySpawnTime;
    private float coinsSpawnTime;
    private float bonusesSpawnTime;


    private void Start()
    {
        settings = FindObjectOfType<Settings>();
        improveManager = FindObjectOfType<ImproveManager>();
        ReadSettings();
        
    }

    private void ReadSettings()
    {
        coinsSpawnDelay = settings.datas[25];
        enemiesSpawnDelay = settings.datas[26];
        bonusesSpawnDelay = settings.datas[27];
        enemiesOn = settings.Bools[0];
        silverCoinsOn = settings.Bools[1];
        goldCoinsOn = settings.Bools[2];
        bossesOn = settings.Bools[3];
        invulnerabilityOn = settings.Bools[4];
        bonusesOn = settings.Bools[5];

    }
    private void WriteSettings()
    {
        settings.Bonuses[0] = coinsSpawnDelay;
        settings.Bonuses[1] = enemiesSpawnDelay;
        settings.Bonuses[2] = bonusesSpawnDelay;
        settings.Bools[0] = enemiesOn;
        settings.Bools[1] = silverCoinsOn;
        settings.Bools[2] = goldCoinsOn;
        settings.Bools[3] = bossesOn;
        settings.Bools[4] = invulnerabilityOn;
        settings.Bools[5] = bonusesOn;
        improveManager.SettingsUpdate();
        ReadSettings();
    }

    public void CoinsSpawnDelay(float value)
    {
        coinsSpawnDelay /= value;
        WriteSettings();
    }

    public void EnemiesSpawnDelay(float value)
    {
        enemiesSpawnDelay /= value;
        WriteSettings();
    }

    public void BonusesSpawnDelay(float value)
    {
        bonusesSpawnDelay /= value;
        WriteSettings();
    }

    public void EnemiesOn()
    {
        enemiesOn = true;
        WriteSettings();
    }

    public void BonusesOn()
    {
        bonusesOn = true;
        WriteSettings();
        bonuses.Add(Resources.Load("Prefab/Chest"));
    }

    public void InvulnerabilityOn()
    {
        invulnerabilityOn = true;
        WriteSettings();
        bonuses.Add(Resources.Load("Prefab/Invulnerability"));
    }

    public void SilverCoinsOn()
    {
        silverCoinsOn = true;
        WriteSettings();
        if (coins.Count < 2)
        {
            coins.Add(Resources.Load("Prefab/SilverCoin"));
        }
    }

    public void GoldCoinsOn()
    {
        goldCoinsOn = true;
        WriteSettings();
        if (coins.Count > 1 && coins.Count < 3)
        {
            coins.Add(Resources.Load("Prefab/GoldCoin"));
        }
    }

    public void BossesOn()
    {
        bossesOn = true;
        WriteSettings();
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

        
        for (int j = spawnObject.Count - 1; j > 0; j--)
        {
            if ((int)UnityEngine.Random.Range(0, (float)Math.Pow(10, j)) < 5)
            {
                randomObject = j;
                break;
            }
        }

        Instantiate(spawnObject[randomObject], transform.position + new Vector3(randomX, randomY, 0.0f), transform.rotation, GameObject.Find("GameManager").transform);

    }

    
}
