using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public float cps;
    public float coins;
    private float sec;
    private float minCps;


    [SerializeField] private TMP_Text cpsText;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private ObstaclesSpawn spawn;

    private void Start()
    {
        coins = PlayerPrefs.GetFloat("coins");
        cps = PlayerPrefs.GetFloat("cps");   
    }

    private void Update()
    {
        if (Time.time > sec)
        {
            AddCoins(cps);
            sec = Time.time + 1;
        }

        if (cps >= 1000f)
        {
            cpsText.text = cps.ToString("e2", CultureInfo.InvariantCulture) + " CpS";
        }
        else if (cps >= 100f && cps < 1000f)
        {
            cpsText.text = Math.Round(cps, 0).ToString() + " CpS";
        }
        else
        {
            cpsText.text = cps.ToString() + " CpS";
        }

        if (coins >= 1000f)
        {
            coinsText.text = coins.ToString("e2", CultureInfo.InvariantCulture) + " CpS";
        }
        else if (coins >= 100f && coins < 1000f)
        {
            coinsText.text = Math.Round(coins, 0).ToString() + " CpS";
        }
        else
        {
            coinsText.text = coins.ToString();
        }

    }

    public void AddCoins(float cost)
    {
        coins += cost;
        coins = (float)Math.Round(coins, 2);
        PlayerPrefs.SetFloat("coins", coins);
    }

    public void Multipier(float mult)
    {
        cps += mult;
        if (cps < 0)
        {
            cps = 0.0f;
        }
        cps = (float)Math.Round(cps, 2);
        PlayerPrefs.SetFloat("cps", cps);
    }

    public void Bonuses(int i)
    {
        if (i == 1)
        {
            spawn.coinsSpawnFrequency /= 100;
            Invoke(nameof(BonusDeactivating), 5.0f);
        }
    }

    private void BonusDeactivating()
    {
        spawn.enemiesSpawnFrequency = 0.5f;
        spawn.coinsSpawnFrequency = 2.0f;
        spawn.bonusesSpawnFrequency = 10.0f;

    }

}
