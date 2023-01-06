using System;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ImproveManager : MonoBehaviour
{

    private Settings settings;
    private float t, tmax = 10;
    private float speed = 1;

    public List<string> effects;

    [SerializeField] private MoneyManager MoneyManager;
    [SerializeField] private ContentFilling ContentFilling;

    private float minCps;
    private float coins;
    private float cps;
    private float killed;

    [SerializeField] private GameObject[] Improves;

    [SerializeField] private TMP_Text[] ButtonTexts;

    [SerializeField] private TMP_Text[] CpSTexts;

    [SerializeField] private TMP_Text[] LvlTexts;

    private float fistsCost = 1e1f;
    private float stickCost = 5e2f;
    private float bbBatCost = 2.4e3f;
    private float rudisCost = 1.5e4f;
    private float swordCost = 1.5e5f;
    private float axeCost = 3.62e7f;
    private float hammerCost = 4.64e8f;

    public float costRising = 1.15f;

    private float fistsLvl;
    private float stickLvl;
    private float bbBatLvl;
    private float rudisLvl;
    private float swordLvl;
    private float axeLvl;
    private float hammerLvl;
    
    private float fistsCps;
    private float stickCps;
    private float bbBatCps;
    private float rudisCps;
    private float swordCps;
    private float axeCps;
    private float hammerCps;
    
    private float multiplier = 1;

    private void Start()
    {
        settings = FindObjectOfType<Settings>();
        ReadSettings();
        t = tmax;
    }
    
    private void Update()
    {
        cps = GetComponent<MoneyManager>().cps;
        minCps = GetComponent<MoneyManager>().minCps;
        coins = GetComponent<MoneyManager>().coins;
        killed = GetComponent<MoneyManager>().killed;
        ShowImprove();
        SetCost();
        SettingsUpdate();
    }

    public void WeaponUpgrade(float value)
    {
        fistsCps *= value;
        stickCps *= value;
        bbBatCps *= value;
        rudisCps *= value;
        swordCps *= value;
        axeCps *= value;
        hammerCps *= value;
    }
    private void ShowImprove()
    {
        float[] Costs = { fistsCost, stickCost, bbBatCost, rudisCost, swordCost, axeCost, hammerCost };


        for (int i = 0; i < Costs.Length; i++)
        {
            if (coins >= 0.9 * Costs[i])
            {
                Improves[i].SetActive(true);
            }
        }
    }

    private void SetCost()
    {
        float[] Costs = { fistsCost, stickCost, bbBatCost, rudisCost, swordCost, axeCost, hammerCost };

        for (int i = 0; i < Costs.Length; i++)
        {
            if (Costs[i] * multiplier >= 1000f)
            {
                ButtonTexts[i].text = (Costs[i] * multiplier).ToString("e2", CultureInfo.InvariantCulture);
            }
            else
            {
                ButtonTexts[i].text = (Costs[i] * multiplier).ToString("f0");
            }
        }

    }

    private void ReadSettings()
    {
        coins = settings.datas[0];
        cps = settings.datas[1];
        minCps = settings.datas[2];
        killed = settings.datas[3];
        fistsLvl = settings.datas[4];
        stickLvl = settings.datas[5];
        bbBatLvl = settings.datas[6];
        rudisLvl = settings.datas[7];
        swordLvl = settings.datas[8];
        axeLvl = settings.datas[9];
        hammerLvl = settings.datas[10];
        fistsCps = settings.datas[11];
        stickCps = settings.datas[12];
        bbBatCps = settings.datas[13];
        rudisCps = settings.datas[14];
        swordCps = settings.datas[15];
        axeCps = settings.datas[16];
        hammerCps = settings.datas[17];
        fistsCost = settings.datas[18];
        stickCost = settings.datas[19];
        bbBatCost = settings.datas[20];
        rudisCost = settings.datas[21];
        swordCost = settings.datas[22];
        axeCost = settings.datas[23];
        hammerCost = settings.datas[24];
    }

    public void SettingsUpdate()
    {
        float[] General = { coins, cps, minCps, killed };
        float[] Lvl = { fistsLvl, stickLvl, bbBatLvl, rudisLvl, swordLvl, axeLvl, hammerLvl };
        float[] CpS = { fistsCps, stickCps, bbBatCps, rudisCps, swordCps, axeCps, hammerCps };
        float[] Costs = { fistsCost, stickCost, bbBatCost, rudisCost, swordCost, axeCost, hammerCost };


        if (t <= 0)
        {
            settings.WriteNewSettings(General, Lvl, CpS, Costs);
            ReadSettings();
            t = tmax;
        }
        else
        {
            t -= Time.deltaTime * speed;
        }
    }

    #region Improves Update
    private void ImproveTextsUpdate(GameObject flvl, GameObject fcps, float impcps, float implvl)
    {
        var fcpsText = fcps.GetComponent<TMP_Text>();
        var flvlText = flvl.GetComponent<TMP_Text>();
        flvlText.text = implvl.ToString("f0") + " level";
        if (impcps >= 1000f)
        {
            fcpsText.text = impcps.ToString("e2", CultureInfo.InvariantCulture) + " CpS";
        }
        else if (impcps >= 100f && impcps < 1000f)
        {
            fcpsText.text = Math.Round(impcps, 0) + " CpS";
        }
        else
        {
            fcpsText.text = Math.Round(impcps, 2) + " CpS";
        }
    }

    private float[] ImproveCostUpdate(float impcost, float impcps, float implvl)
    {

        coins -= impcost * multiplier;
        MoneyManager.CoinsUpdate(coins);
        cps -= minCps;
        minCps -= impcps;
        impcps += (impcost * costRising / 100) * multiplier;
        minCps += impcps;
        MoneyManager.MinCpsUpdate(minCps);
        cps += minCps;
        MoneyManager.CpsUpdate(cps);
        impcost *= costRising;
        implvl += multiplier;
        float[] arr = new float[3];
        arr[0] = impcost;
        arr[1] = impcps;
        arr[2] = implvl;

        return arr;
    }

    public void SetFists()
    {
        if (coins >= fistsCost * multiplier)
        {
            if (fistsCps == 0)
            {
                effects.Add($"Fists = 0 = {fistsCost} = 0");
            }
            float[] arr = ImproveCostUpdate(fistsCost, fistsCps, fistsLvl);
            fistsCost = arr[0];
            fistsCps = arr[1];
            fistsLvl = arr[2];
        }

        var flvl = GameObject.Find("FistsLvl");
        var fcps = GameObject.Find("FistsCpS");
        ImproveTextsUpdate(flvl, fcps, fistsCps, fistsLvl);
    }
 
    public void SetStick()
    {
        if (coins >= stickCost * multiplier)
        {
            if (stickCps == 0)
            {
                effects.Add($"Stick = 0 = {stickCost} = 0");
            }
            float[] arr = ImproveCostUpdate(stickCost, stickCps, stickLvl);
            stickCost = arr[0];
            stickCps = arr[1];
            stickLvl = arr[2];
        }

        var flvl = GameObject.Find("StickLvl");
        var fcps = GameObject.Find("StickCpS");
        ImproveTextsUpdate(flvl, fcps, stickCps, stickLvl);

    }

    public void SetBbBat()
    {
        if (coins >= bbBatCost * multiplier)
        {
            if (bbBatCps == 0)
            {
                effects.Add($"BbBat = 0 = {bbBatCost} = 0");
            }
            float[] arr = ImproveCostUpdate(bbBatCost, bbBatCps, bbBatLvl);
            bbBatCost = arr[0];
            bbBatCps = arr[1];
            bbBatLvl = arr[2];
        }

        var flvl = GameObject.Find("BbBatLvl");
        var fcps = GameObject.Find("BbBatCpS");
        ImproveTextsUpdate(flvl, fcps, bbBatCps, bbBatLvl);

    }

    public void SetRudis()
    {
        if (coins >= rudisCost * multiplier)
        {
            if (rudisCps == 0)
            {
                effects.Add($"Rudis = 0 = {rudisCost} = 0");
            }
            float[] arr = ImproveCostUpdate(rudisCost, rudisCps, rudisLvl);
            rudisCost = arr[0];
            rudisCps = arr[1];
            rudisLvl = arr[2];
        }

        var flvl = GameObject.Find("RudisLvl");
        var fcps = GameObject.Find("RudisCpS");
        ImproveTextsUpdate(flvl, fcps, rudisCps, rudisLvl);

    }

    public void SetSword()
    {
        if (coins >= swordCost * multiplier)
        {
            if (swordCps == 0)
            {
                effects.Add($"Sword = 0 = {swordCost} = 0");
            }
            float[] arr = ImproveCostUpdate(swordCost, swordCps, swordLvl);
            swordCost = arr[0];
            swordCps = arr[1];
            swordLvl = arr[2];
        }

        var flvl = GameObject.Find("SwordLvl");
        var fcps = GameObject.Find("SwordCpS");
        ImproveTextsUpdate(flvl, fcps, swordCps, swordLvl);

    }

    public void SetAxe()
    {
        if (coins >= axeCost * multiplier)
        {
            if (axeCps == 0)
            {
                effects.Add($"Axe = 0 = {axeCost} = 0");
            }
            float[] arr = ImproveCostUpdate(axeCost, axeCps, axeLvl);
            axeCost = arr[0];
            axeCps = arr[1];
            axeLvl = arr[2];
        }

        var flvl = GameObject.Find("AxeLvl");
        var fcps = GameObject.Find("AxeCpS");
        ImproveTextsUpdate(flvl, fcps, axeCps, axeLvl);

    }

    public void SetHammer()
    {
        if (coins >= hammerCost * multiplier)
        {
            if (hammerCps == 0)
            {
                effects.Add($"Hammer = 0 = {hammerCost} = 0");
            }
            float[] arr = ImproveCostUpdate(hammerCost, hammerCps, hammerLvl);
            hammerCost = arr[0];
            hammerCps = arr[1];
            hammerLvl = arr[2];
        }

        var flvl = GameObject.Find("HammerLvl");
        var fcps = GameObject.Find("HammerCpS");
        ImproveTextsUpdate(flvl, fcps, hammerCps, hammerLvl);

    }

    #endregion



    #region Multipliers
    public void SetX1Multiplier()
    {
        multiplier = 1;
    }

    public void SetX10Multiplier()
    {
        multiplier = 10;
    }

    public void SetX50Multiplier()
    {
        multiplier = 50;
    }
    #endregion
}
