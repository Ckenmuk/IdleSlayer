using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

public class Settings : MonoBehaviour
{
    public float coins;
    public float cps;
    public float minCps;
    
    public float fistsLvl;
    public float stickLvl;
    public float bbBatLvl;
    public float rudisLvl;
    public float swordLvl;

    public float fistsCps;
    public float stickCps;
    public float bbBatCps;
    public float rudisCps;
    public float swordCps;

    private float[] datas;

    public string path;

    public string[] data { get; private set; } = new string[0];
    public string[] effects;

    [System.Obsolete]
    void Start()
    {
        datas = new float[]
        {
            coins,
            cps,
            minCps,

            fistsLvl,
            stickLvl,
            bbBatLvl,
            rudisLvl,
            swordLvl,

            fistsCps,
            stickCps,
            bbBatCps,
            rudisCps,
            swordCps
        };
        Application.DontDestroyOnLoad(gameObject);

        if (path.Length == 0)
        {
            path = Application.dataPath + "/";
        }

        if (File.Exists(path + "settings.ini"))
        {
            Read();
        }

        SceneManager.LoadScene(1);
    }

    private void Update()
    {

        if (!File.Exists(path + "settings.ini"))
        {
            WriteDefault();
        }
    }
    public void Read()
    {
        data = File.ReadAllLines(path + "settings.ini");
        for (int i = 0; i < data.ToList().IndexOf("effects begin"); i++)
        {
            datas[i] = (float)double.Parse(data[i].Remove(0, data[i].IndexOf("=") + 2));
        }

        effects = File.ReadAllLines(path + "Adds.ini");
        for (int i = data.ToList().IndexOf("effects begin") + 1; i < data.ToList().IndexOf("effects end"); i++)
        {
            //искать первый, второй и третий разделители
        }

    }

    private void WriteDefault()
    {
        List<string> td = new List<string>();

        td.Add("coins = 0");
        td.Add("cps = 0");
        td.Add("minCps = 0");

        //effectname = levl = cost = cps
        td.Add("effects begin");
        td.Add("");
        td.Add("effects end");
        

        File.WriteAllLines(path + "settings.ini", td.ToArray());

        Read();
    }

    public void WriteNewSettings(float coins, float cps, float min_cps)
    {
        List<string> td = new List<string>();

        td.Add($"coins = {coins}");
        td.Add($"cps = {cps}");
        td.Add($"minCps = { min_cps}");

        string WriteEffects = "";

        for (int i = 0; i < effects.Length; i++) { WriteEffects += effects[i] + "\n"; }

        td.Add("effects begin");
        td.Add(WriteEffects.Remove(WriteEffects.Length - 2));
        td.Add("effects end");
        

        File.WriteAllLines(path + "settings.ini", td.ToArray());

        Read();
    }
}
