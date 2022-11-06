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
        SetPlayerPrefs();
    }

    private void Start()
    {
        Reset();

        GetPlayerPrefs();
    }

    
    private void Update()
    {
        cps = GetComponent<MoneyManager>().cps;
        minCps = GetComponent<MoneyManager>().minCps;
        coins = GetComponent<MoneyManager>().coins;
        ShowImprove();
        SetCost();
        SetPlayerPrefs();
        Debug.Log(coins.ToString());

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
        if (coins >= fistsCost * multiplier)
        {
            coins -= fistsCost * multiplier;
            MoneyManager.CoinsUpdate(coins);
            fistsLvl += multiplier;
            cps -= minCps;
            minCps -= fistsCps;
            fistsCps += 0.1f * multiplier;
            minCps += fistsCps;
            MoneyManager.MinCpsUpdate(minCps);
            cps += minCps;
            MoneyManager.CpsUpdate(cps);
            fistsCost *= 1.1f;
        }

        var flvl = GameObject.Find("FistsLvl");
        var flvlText = flvl.GetComponent<TMP_Text>();
        flvlText.text = fistsLvl.ToString("f0") + "level";

        var fcps = GameObject.Find("FistsCpS");
        var fcpsText = fcps.GetComponent<TMP_Text>();
        fcpsText.text = fistsCps.ToString("f0") + " CpS";
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


    private void SetPlayerPrefs()
    {
       /* PlayerPrefs.SetFloat("fistsCost", fistsCost);
        PlayerPrefs.SetFloat("stickCost", stickCost);
        PlayerPrefs.SetFloat("bbBatCost", bbBatCost);
        PlayerPrefs.SetFloat("rudisCost", rudisCost);
        PlayerPrefs.SetFloat("swordCost", swordCost);

        PlayerPrefs.SetFloat("fistsLvl", fistsLvl);
        PlayerPrefs.SetFloat("stickLvl", stickLvl);
        PlayerPrefs.SetFloat("bbBatLvl", bbBatLvl);
        PlayerPrefs.SetFloat("rudisLvl", rudisLvl);
        PlayerPrefs.SetFloat("swordLvl", swordLvl);

        PlayerPrefs.SetFloat("fistsCps", fistsCps);
        PlayerPrefs.SetFloat("stickCps", stickCps);
        PlayerPrefs.SetFloat("bbBatCps", bbBatCps);
        PlayerPrefs.SetFloat("rudisCps", rudisCps);
        PlayerPrefs.SetFloat("swordCps", swordCps);
        */
    }

    private void GetPlayerPrefs()
    {
     /*   fistsCost = PlayerPrefs.GetFloat("fistsCost");
        stickCost = PlayerPrefs.GetFloat("stickCost");
        bbBatCost = PlayerPrefs.GetFloat("bbBatCost");
        rudisCost = PlayerPrefs.GetFloat("rudisCost");
        swordCost = PlayerPrefs.GetFloat("swordCost");

        fistsLvl = PlayerPrefs.GetFloat("fistsLvl");
        stickLvl = PlayerPrefs.GetFloat("stickLvl");
        bbBatLvl = PlayerPrefs.GetFloat("bbBatLvl");
        rudisLvl = PlayerPrefs.GetFloat("rudisLvl");
        swordLvl = PlayerPrefs.GetFloat("swordLvl");

        fistsCps = PlayerPrefs.GetFloat("fistsCps");
        stickCps = PlayerPrefs.GetFloat("stickCps");
        bbBatCps = PlayerPrefs.GetFloat("bbBatCps");
        rudisCps = PlayerPrefs.GetFloat("rudisCps");
        swordCps = PlayerPrefs.GetFloat("swordCps");

        coins = PlayerPrefs.GetFloat("coins");
        cps = PlayerPrefs.GetFloat("cps");
        minCps = PlayerPrefs.GetFloat("minCps");*/
    }
}
