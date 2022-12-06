using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ContentFilling : MonoBehaviour
{
    [SerializeField] private MoneyManager MoneyManager;

    private string[] data;
    public List<float> Costs;

    private float cps;
    private float minCps;
    private float coins;


    private void Start()
    {
        data = FindObjectOfType<Settings>().data;
        ReadSettings();
    }

    void Update()
    {
        cps = GetComponent<MoneyManager>().cps;
        minCps = GetComponent<MoneyManager>().minCps;
        coins = GetComponent<MoneyManager>().coins;
        Debug.Log(Costs[3]);
        Debug.Log(Costs.Count);
    }

    private void ReadSettings()
    {
        for (int i = data.ToList().IndexOf("effects begin") + 1; i < data.ToList().IndexOf("effects end"); i++)
        {
            string startRemove = data[i].Remove(0, data[i].IndexOf(";") + 2);
            string endRemove = startRemove.Remove(startRemove.IndexOf(";") - 1);
            float cost = (float)double.Parse(endRemove);
            Costs.Add(cost);

        }
    }

}
