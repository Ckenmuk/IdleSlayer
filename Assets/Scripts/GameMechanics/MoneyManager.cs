using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private Settings settings;
    private ImproveManager improveManager;
    public float cps { get; private set; }
    public float coins { get; private set; }
    public float minCps { get; private set; }
    public float killed { get; private set; }
    private float sec;

    private float chestUpdate = 1.0f;
    public bool ifGameClosed = false;

    private float esd;
    private float csd;
    private float bsd;

    [SerializeField] private TMP_Text cpsText;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text killedText;
    [SerializeField] private ObstaclesSpawn spawn;

    private void Start()
    {
        settings = FindObjectOfType<Settings>();
        improveManager = FindObjectOfType<ImproveManager>();
        ReadSettings();
        ifGameClosed = false;
    }

    private void ReadSettings()
    {
        coins = settings.datas[0];
        cps = settings.datas[1];
        minCps = settings.datas[2];
        killed = settings.datas[3];
        chestUpdate = settings.datas[28];
        ifGameClosed = settings.Bools[6];
    }

    private void WriteSettings()
    {
        settings.datas[28] = chestUpdate;
        settings.Bools[6] = ifGameClosed;
        improveManager.SettingsUpdate();
        ReadSettings();
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
            cpsText.text = Math.Round(cps, 0) + " CpS";
        }
        else
        {
            cpsText.text = Math.Round(cps, 2) + " CpS";
        }

        if (coins >= 1000f)
        {
            coinsText.text = coins.ToString("e2", CultureInfo.InvariantCulture);
        }
        else if (coins >= 100f && coins < 1000f)
        {
            coinsText.text = ((int)(coins * 10) * 0.1f) + "";
        }
        else
        {
            coinsText.text = Math.Round(coins, 2) + "";
        }
        killedText.text = killed + " killed";

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
        coins = (float)Math.Round(coins, 2);
    }

    public void GainCpS(float value)
    {
        if (minCps > 0)
        {
            cps -= minCps;
            minCps *= value;
            cps += minCps;
        }
        else
        {
            minCps = 0.5f;
        }

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

        cps = (float)Math.Round(cps, 2);
    }

    public void IfGameClosed()
    {
        ifGameClosed = true;
        WriteSettings();
    }

    public void Bonuses(int i)
    {
        esd = spawn.enemiesSpawnDelay;
        csd = spawn.coinsSpawnDelay;
        bsd = spawn.bonusesSpawnDelay;

        switch (i)
        {
            case 1:
                spawn.coinsSpawnDelay /= 100 * chestUpdate;
                break;
            case 2:
                spawn.enemiesSpawnDelay /= 10 * chestUpdate;
                break;
            default:
                break;
        }

        Invoke(nameof(BonusDeactivating), 5.0f);
    }

    private void BonusDeactivating()
    {
        spawn.enemiesSpawnDelay = esd;
        spawn.coinsSpawnDelay = csd;
        spawn.bonusesSpawnDelay = bsd;

    }

    public void ChestUpgrade(float value)
    {
        chestUpdate *= value;
        WriteSettings();
    }


}
