using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class ContentFilling : MonoBehaviour
{
    [SerializeField] private MoneyManager MoneyManager;
    [SerializeField] private GameObject AddPanel;
    private GameObject Content;

    private string[] data;
    public List<string> Titles;
    public List<float> Costs;
    public List<string> Texts;
    public List<string> Methods;
    public List<float> Values;

    private string startRemove;
    private string endRemove;

    private float cps;
    private float minCps;
    private float coins;


    private void Start()
    {
        data = FindObjectOfType<Settings>().data;
        Content = GetComponent<AddsController>().Content;
        ReadSettings();
    }

    void Update()
    {
        cps = GetComponent<MoneyManager>().cps;
        minCps = GetComponent<MoneyManager>().minCps;
        coins = GetComponent<MoneyManager>().coins;
    }

    private void ReadSettings()
    {
        for (int i = data.ToList().IndexOf("effects begin") + 1; i < data.ToList().IndexOf("effects end"); i++)
        {

            startRemove = data[i].Remove(data[i].IndexOf(";") - 1);
            if (!Titles.Contains(startRemove))
            {
                //titles
                Titles.Add(startRemove);

                //costs
                startRemove = data[i].Remove(0, data[i].IndexOf(";") + 2);
                endRemove = startRemove.Remove(startRemove.IndexOf(";") - 1);
                float value = (float)double.Parse(endRemove);
                Costs.Add(value);

                //texts
                startRemove = data[i].Remove(0, data[i].IndexOf(";") + 2);
                startRemove = startRemove.Remove(0, startRemove.IndexOf(";") + 2);
                endRemove = startRemove.Remove(startRemove.IndexOf(";") - 1);
                Texts.Add(endRemove);

                //methods
                startRemove = data[i].Remove(data[i].LastIndexOf(";") - 1);
                endRemove = startRemove.Remove(0, startRemove.LastIndexOf(";") + 2);
                Methods.Add(endRemove);

                //values to methods
                startRemove = data[i].Remove(0, data[i].LastIndexOf(";") + 2);
                value = (float)double.Parse(startRemove);
                Values.Add(value);
            }
        }

        for (int i = 0; i < Titles.Count; i++)
        {
            GameObject to = Instantiate(AddPanel);
            to.name = Titles[i];
            to.transform.GetChild(1).GetComponent<TMP_Text>().text = Texts[i];
            if (Costs[i] >= 10000)
            {
                to.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = Costs[i].ToString("e2", CultureInfo.InvariantCulture);
            }
            else
            {
                to.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = Costs[i].ToString("f0", CultureInfo.InvariantCulture);
            }
            to.GetComponent<AddAddative>().title = Titles[i];
            to.GetComponent<AddAddative>().value = Values[i];
            to.transform.position = Content.transform.position;
            to.transform.rotation = Content.transform.rotation;
            to.transform.SetParent(Content.transform);
        }

    }

}
