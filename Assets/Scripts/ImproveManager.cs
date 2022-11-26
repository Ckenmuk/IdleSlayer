using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ImproveManager : MonoBehaviour
{
    [SerializeField] private MoneyManager MoneyManager;

    private float minCps;
    private float coins;
    private float cps;

    [SerializeField] private GameObject[] Improves;

    [SerializeField] private TMP_Text[] ButtonTexts;

    [SerializeField] private TMP_Text[] CpSTexts;

    [SerializeField] private TMP_Text[] LvlTexts;

    private float fistsCost = 10;
    private float stickCost = 500;
    private float bbBatCost = 2500;
    private float rudisCost = 12500;
    private float swordCost = 62500;

    private float fistsLvl;
    private float stickLvl;
    private float bbBatLvl;
    private float rudisLvl;
    private float swordLvl;
    
    private float fistsCps;
    private float stickCps;
    private float bbBatCps;
    private float rudisCps;
    private float swordCps;


    private float multiplier = 1;


    private void Reset()
    {
        fistsCost = 10;
        stickCost = 500;
        bbBatCost = 2500;
        rudisCost = 12500;
        swordCost = 62500;

        fistsCps = 0;
        stickCps = 0;
        bbBatCps = 0;
        rudisCps = 0;
        swordCps = 0;

        fistsLvl = 0;
        stickLvl = 0;
        bbBatLvl = 0;
        rudisLvl = 0;
        swordLvl = 0;
    }

    private void Start()
    {
        //Reset();

    }

    
    private void Update()
    {
        cps = GetComponent<MoneyManager>().cps;
        minCps = GetComponent<MoneyManager>().minCps;
        coins = GetComponent<MoneyManager>().coins;
        ShowImprove();
        SetCost();

    }

    private void SetCost()
    {
        float[] Costs = { fistsCost, stickCost, bbBatCost, rudisCost, swordCost };

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


    public void SetFists()
    {
        Debug.Log(1);
        if (coins >= fistsCost * multiplier)
        {
            coins -= fistsCost * multiplier;
            MoneyManager.CoinsUpdate(coins);
            fistsLvl += multiplier;
            cps -= minCps;
            minCps -= fistsCps;
            fistsCps += (fistsCost / 100) * multiplier;
            minCps += fistsCps;
            MoneyManager.MinCpsUpdate(minCps);
            cps += minCps;
            MoneyManager.CpsUpdate(cps);
            fistsCost *= 1.1f;
        }

        var flvl = GameObject.Find("FistsLvl");
        var flvlText = flvl.GetComponent<TMP_Text>();
        flvlText.text = fistsLvl.ToString("f0") + " level";

        var fcps = GameObject.Find("FistsCpS");
        var fcpsText = fcps.GetComponent<TMP_Text>();
        fcpsText.text = fistsCps.ToString("f1") + " CpS";
    }

    public void SetStick()
    {
        if (coins >= stickCost * multiplier)
        {
            coins -= stickCost * multiplier;
            MoneyManager.CoinsUpdate(coins);
            stickLvl += multiplier;
            cps -= minCps;
            minCps -= stickCps;
            stickCps += (stickCost / 100) * multiplier;
            minCps += stickCps;
            MoneyManager.MinCpsUpdate(minCps);
            cps += minCps;
            MoneyManager.CpsUpdate(cps);
            stickCost *= 1.1f;
        }

        var flvl = GameObject.Find("StickLvl");
        var flvlText = flvl.GetComponent<TMP_Text>();
        flvlText.text = stickLvl.ToString("f0") + " level";

        var fcps = GameObject.Find("StickCpS");
        var fcpsText = fcps.GetComponent<TMP_Text>();
        fcpsText.text = stickCps.ToString("f1") + " CpS";
    }

    public void SetBbBat()
    {
        if (coins >= bbBatCost * multiplier)
        {
            coins -= bbBatCost * multiplier;
            MoneyManager.CoinsUpdate(coins);
            bbBatLvl += multiplier;
            cps -= minCps;
            minCps -= bbBatCps;
            bbBatCps += (bbBatCost / 100) * multiplier;
            minCps += bbBatCps;
            MoneyManager.MinCpsUpdate(minCps);
            cps += minCps;
            MoneyManager.CpsUpdate(cps);
            bbBatCost *= 1.1f;
        }

        var flvl = GameObject.Find("BbBatLvl");
        var flvlText = flvl.GetComponent<TMP_Text>();
        flvlText.text = bbBatLvl.ToString("f0") + " level";

        var fcps = GameObject.Find("BbBatCpS");
        var fcpsText = fcps.GetComponent<TMP_Text>();
        fcpsText.text = bbBatCps.ToString("f1") + " CpS";
    }

    public void SetRudis()
    {
        if (coins >= rudisCost * multiplier)
        {
            coins -= rudisCost * multiplier;
            MoneyManager.CoinsUpdate(coins);
            rudisLvl += multiplier;
            cps -= minCps;
            minCps -= rudisCps;
            rudisCps += (rudisCost / 100) * multiplier;
            minCps += rudisCps;
            MoneyManager.MinCpsUpdate(minCps);
            cps += minCps;
            MoneyManager.CpsUpdate(cps);
            rudisCost *= 1.1f;
        }

        var flvl = GameObject.Find("RudisLvl");
        var flvlText = flvl.GetComponent<TMP_Text>();
        flvlText.text = rudisLvl.ToString("f0") + " level";

        var fcps = GameObject.Find("RudisCpS");
        var fcpsText = fcps.GetComponent<TMP_Text>();
        fcpsText.text = rudisCps.ToString("f1") + " CpS";
    }

    public void SetSword()
    {
        if (coins >= swordCost * multiplier)
        {
            coins -= swordCost * multiplier;
            MoneyManager.CoinsUpdate(coins);
            swordLvl += multiplier;
            cps -= minCps;
            minCps -= swordCps;
            swordCps += (swordCost / 100) * multiplier;
            minCps += swordCps;
            MoneyManager.MinCpsUpdate(minCps);
            cps += minCps;
            MoneyManager.CpsUpdate(cps);
            swordCost *= 1.1f;
        }

        var flvl = GameObject.Find("SwordLvl");
        var flvlText = flvl.GetComponent<TMP_Text>();
        flvlText.text = swordLvl.ToString("f0") + " level";

        var fcps = GameObject.Find("SwordCpS");
        var fcpsText = fcps.GetComponent<TMP_Text>();
        fcpsText.text = swordCps.ToString("f1") + " CpS";
    }


    private void ShowImprove()
    {
        float[] Costs = { fistsCost, stickCost, bbBatCost, rudisCost, swordCost };
        
        for (int i = 0; i < Costs.Length; i++)
        {
            if (coins > Costs[i])
            {
                Improves[i].SetActive(true);
            }
        }
    }

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



}
