using System;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public float cps;
    public float coins;
    private float sec;

    [SerializeField] private TMP_Text cpsText;
    [SerializeField] private TMP_Text coinsText;


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


        cpsText.text = cps.ToString() + " CpS";
        coinsText.text = coins.ToString();
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

}
