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

        t = tmax;
    }
    
    private void Update()
    {
        cps = GetComponent<MoneyManager>().cps;
        minCps = GetComponent<MoneyManager>().minCps;
        coins = GetComponent<MoneyManager>().coins;
        ShowImprove();
        SetCost();
        SettingsUpdate();
    }

    private void ShowImprove()
    {
        float[] Costs = { fistsCost, stickCost, bbBatCost, rudisCost, swordCost, axeCost, hammerCost };

        for (int i = 0; i < Costs.Length; i++)
        {
            if (coins >= Costs[i])
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
            if (Costs[i] * multiplier >= 10000f)
            {
                ButtonTexts[i].text = (Costs[i] * multiplier).ToString("e2", CultureInfo.InvariantCulture);
            }
            else
            {
                ButtonTexts[i].text = (Costs[i] * multiplier).ToString("f0");
            }
        }

    }

    private void SettingsUpdate()
    {

        if (t <= 0)
        {
            settings.coins = coins;
            settings.cps = cps;
            settings.minCps = minCps;

            settings.WriteNewSettings(coins, cps, minCps);

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
