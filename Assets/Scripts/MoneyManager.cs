using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public float cps { get; private set; }
    public float coins { get; private set; }
    public float minCps { get; private set; }

    private float killed;
    private float sec;


    [SerializeField] private TMP_Text cpsText;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text killedText;
    [SerializeField] private ObstaclesSpawn spawn;

    private void Start()
    {
    }

    private void Update()
    {
        GetPlayerPrefs();
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

        if (coins >= 10000f)
        {
            coinsText.text = coins.ToString("e2", CultureInfo.InvariantCulture);
        }
        else if (coins >= 100f && coins < 10000f)
        {
            coinsText.text = Math.Round(coins, 0).ToString();
        }
        else
        {
            coinsText.text = coins.ToString();
        }
        killedText.text = killed.ToString() + " killed";

    }

    public void CoinsUpdate(float coins)
    {
        this.coins = coins;
    }

    public void CpsUpdate(float cps)
    {
        this.cps = cps;
    }

    public void MinCpsUpdate(float minCps)
    {
        this.minCps = minCps;
    }

    public void AddCoins(float cost)
    {
        coins += cost;
        coins = (float)Math.Round(coins, 2);/*
        PlayerPrefs.SetFloat("coins", coins);*/
    }

    public void Multipier(float mult, bool plus)
    {
        cps += mult;
        if (cps < 0)
        {
            cps = minCps;
        }

        if (plus)
        {
            killed++;
        }
        else
        {
            killed = 0;
        }

        cps = (float)Math.Round(cps, 2);/*
        PlayerPrefs.SetFloat("cps", cps);
        PlayerPrefs.SetFloat("killed", killed);*/
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

    private void GetPlayerPrefs()
    {/*
        coins = PlayerPrefs.GetFloat("coins");
        cps = PlayerPrefs.GetFloat("cps");
        minCps = PlayerPrefs.GetFloat("minCps");
        killed = PlayerPrefs.GetFloat("killed");*/
    }

}
