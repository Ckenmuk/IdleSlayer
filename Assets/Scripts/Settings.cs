using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class Settings : MonoBehaviour
{
    float[] General = new float[4];
    float[] Lvl = new float[7];
    float[] CpS = new float[7];
    float[] Costs = new float[7];
    public float[] Bonuses = new float[4];
    public bool[] Bools = new bool[7];

    public float coins;
    public float cps;
    public float minCps;
    
    public float[] datas;

    public string path;

    public string[] data { get; private set; } = new string[0];
    public List<string> effects;
    public List<string> Adds;

    [System.Obsolete]
    void Start()
    {
        effects.Add("Add 1 ; 40 ; More coins appear ; CoinsSpawnDelay ; 1,5");
        effects.Add("Add 2 ; 80 ; Gain 100 % bonus CpS ; GainCpS; 2");
        effects.Add("Add 3 ; 200 ; Enemies appear. CpS for kill = 0, 01 ; EnemiesOn ; 1");
        effects.Add("Add 4 ; 800 ; Silver coins appear.Cost = 10 ; SilverCoinsOn ; 1");
        effects.Add("Add 5 ; 5120 ; Gain 2 % bonus CpS ; GainCpS ; 1,02");
        effects.Add("Add 6 ; 10000 ; Bosses appear. CpS = 0.1.BE CAREFUL He brings destructions ; BossesOn ; 1");
        effects.Add("Add 7 ; 30000 ; Increase 5 % coins value ; CoinsCost ; 1,05");
        effects.Add("Add 8 ; 32000 ; More enemies ; EnemiesSpawnDelay ; 1,5");
        effects.Add("Add 9 ; 40000 ; New bonus: Chest.Cointain random improve ; BonusesOn ; 1");
        effects.Add("Add 10 ; 200000 ; Gain 20 % bonus CpS ; GainCpS ; 1,2");
        effects.Add("Add 11 ; 30640000 ; More coins appear ; CoinsSpawnDelay ; 1,1");
        effects.Add("Add 12 ; 400000000 ; Gold coins appear.Cost = 100 ; GoldCoinsOn ; 1");
        effects.Add("Add 13 ; 2000000000 ; More enemies ; EnemiesSpawnDelay ; 1,1");
        effects.Add("Add 14 ; 2000000000 ; Increase 10 % coins value ; CoinsCost ; 1,1");
        effects.Add("Add 15 ; 2280000000 ; New bonus: Invulnerability.Swords and meteors aren't so scary anymore ; InvulnerabilityOn ; 1");
        effects.Add("Add 16 ; 14200000000 ; Gain 50 % bonus CpS ; GainCpS ; 1,5");
        effects.Add("Add 17 ; 82000000000 ; Collect resourses, if game is closed ; IfGameClosed ; 1");
        effects.Add("Add 18 ; 400000000000 ; All weapon gives 100% more CpS ; WeaponUpgrade ; 2");
        effects.Add("Add 19 ; 10000000000000 ; Chest upgrade. Contains more coins ; ChestUpgrade ; 1,5");
        effects.Add("Add 20 ; 40000000000000 ; Increase 20% coins value ; CoinsCost ; 1,2");
        effects.Add("Add 21 ; 51200000000000 ; More enemies ; EnemiesSpawnDelay ; 1,5");
        effects.Add("Add 22 ; 100000000000000 ; You're ultra killer! ; TalentsOn ; 1");

        datas = new float[36];


        

    Application.DontDestroyOnLoad(gameObject);
        Application.runInBackground = true;

        if (path.Length == 0)
        {
            path = Application.persistentDataPath + "/";
        }

        if (File.Exists(path + "settings.ini"))
        {
            Read();
        }

    }

    private void Update()
    {
        //Debug.Log(System.DateTime.Now.DayOfWeek);

        if (!File.Exists(path + "settings.ini"))
        {
            WriteDefault();
        }
    }
    public void Read()
    {
        data = File.ReadAllLines(path + "settings.ini");

        for (int i = 0; i < General.Length; i++)
        {
            datas[i] = float.Parse(data[i].Remove(0, data[i].IndexOf(" = ") + 2));
            General[i] = datas[i];
        }
        for (int i = General.Length; i < (Lvl.Length + General.Length); i++)
        {
            datas[i] = float.Parse(data[i].Remove(0, data[i].IndexOf(" = ") + 2));
            Lvl[i - General.Length] = datas[i];
        }
        for (int i = (General.Length + Lvl.Length); i < (CpS.Length * 2) + General.Length; i++)
        {
            datas[i] = float.Parse(data[i].Remove(0, data[i].IndexOf(" = ") + 2));
            CpS[i - (General.Length + Lvl.Length)] = datas[i];
        }
        for (int i = (General.Length + Lvl.Length + CpS.Length); i < ((Costs.Length * 3) + General.Length); i++)
        {
            datas[i] = float.Parse(data[i].Remove(0, data[i].IndexOf(" = ") + 2));
            Costs[i - (General.Length + Costs.Length * 2)] = datas[i];
        }
        for (int i = (General.Length + Lvl.Length + CpS.Length + Costs.Length); i < ((Costs.Length * 3) + General.Length + Bonuses.Length); i++)
        {
            datas[i] = float.Parse(data[i].Remove(0, data[i].IndexOf(" = ") + 2));
            Bonuses[i - (General.Length + Lvl.Length + CpS.Length + Costs.Length)] = datas[i];
        }
        for (int i = (General.Length + Lvl.Length + CpS.Length + Costs.Length + Bonuses.Length); i < ((Costs.Length * 3) + General.Length + Bonuses.Length + Bools.Length); i++)
        {
            datas[i] = float.Parse(data[i].Remove(0, data[i].IndexOf(" = ") + 2));
            bool float2bool;
            if (datas[i] == 1) { float2bool = true; }
            else { float2bool = false; }
            Bools[i - (General.Length + Lvl.Length + CpS.Length + Costs.Length + Bonuses.Length)] = float2bool;
        }

        Adds.Clear();
        for (int i = Array.IndexOf(data, "effects begin") + 1; i < Array.IndexOf(data, "effects end"); i++)
        {
            Adds.Add(data[i]);
        }


    }

    private void WriteDefault()
    {
        datas[General.Length + (Lvl.Length * 2)] = 1e1f;
        datas[General.Length + (Lvl.Length * 2) + 1] = 5e2f;
        datas[General.Length + (Lvl.Length * 2) + 2] = 2.4e3f;
        datas[General.Length + (Lvl.Length * 2) + 3] = 1.5e4f;
        datas[General.Length + (Lvl.Length * 2) + 4] = 1.5e5f;
        datas[General.Length + (Lvl.Length * 2) + 5] = 3.62e7f;
        datas[General.Length + (Lvl.Length * 2) + 6] = 4.64e8f;
        datas[General.Length + (Lvl.Length * 3)] = 2.0f;
        datas[General.Length + (Lvl.Length * 3) + 1] = 5.0f;
        datas[General.Length + (Lvl.Length * 3) + 2] = 30.0f;
        List<string> td = new List<string>();

        for (int i = 0; i < General.Length; i++)
        {
            td.Add($"General[{i}] = " + datas[i]);
        }
        for (int i = General.Length; i < General.Length + Lvl.Length; i++)
        {
            td.Add($"Lvl[{i - General.Length}] = " + datas[i]);
        }
        for (int i = (General.Length + Lvl.Length); i < General.Length + (Lvl.Length) * 2; i++)
        {
            td.Add($"Cps[{i - (General.Length + Lvl.Length)}] = " + datas[i]);
        }
        for (int i = (General.Length + (Lvl.Length * 2)); i < General.Length + (Lvl.Length * 3); i++)
        {
            td.Add($"Costs[{i - (General.Length + Lvl.Length * 2)}] = " + datas[i]);
        }
        for (int i = (General.Length + (Lvl.Length * 3)); i < General.Length + (Lvl.Length * 3) + Bonuses.Length; i++)
        {
            td.Add($"Bonuses[{i - (General.Length + Lvl.Length * 3)}] = " + datas[i]);
        }
        for (int i = (General.Length + (Lvl.Length * 3) + Bonuses.Length); i < (General.Length + (Lvl.Length * 3) + Bonuses.Length + Bools.Length); i++)
        {
            float bool2float;
            if (Bools[i - (General.Length + (Lvl.Length * 3) + Bonuses.Length)]) { bool2float = 1; }
            else { bool2float = 0; }
            td.Add($"Bools[{i - (General.Length + (Lvl.Length * 3) + Bonuses.Length)}] = " + bool2float);
        }

        td.Add("effects begin");
        for (int i = 0; i < effects.Count; i++)
        {
            td.Add(effects[i]);
        }
        td.Add("effects end");
        

        File.WriteAllLines(path + "settings.ini", td.ToArray());

        Read();
    }

    public void WriteNewSettings(float[] General, float[] Lvl, float[] CpS, float[] Costs)
    {
        List<string> td = new List<string>();

        for (int i = 0; i < General.Length; i++)
        {
            datas[i] = General[i];
            td.Add($"General[{i}] = {General[i]}");
        }

        for (int i = 0; i < Lvl.Length; i++)
        {
            datas[General.Length + i] = Lvl[i];
            td.Add($"Lvl[{i}] = {Lvl[i]}");
        }

        for (int i = 0; i < CpS.Length; i++)
        {
            datas[i + General.Length + Lvl.Length] = CpS[i];
            td.Add($"CpS[{i}] = {CpS[i]}");
        }

        for (int i = 0; i < Costs.Length; i++)
        {
            datas[i + General.Length + Lvl.Length + Costs.Length] = Costs[i];
            td.Add($"Costs[{i}] = {Costs[i]}");
        }
        for (int i = 0; i < Bonuses.Length; i++)
        {
            datas[i + General.Length + Lvl.Length + Costs.Length + CpS.Length] = Bonuses[i];
            td.Add($"Bonuses[{i}] = {Bonuses[i]}");
        }
        for (int i = 0; i < Bools.Length; i++)
        {
            float bool2float;
            if (Bools[i]) { bool2float = 1; }
            else { bool2float = 0; }
            datas[i + General.Length + Lvl.Length + Costs.Length + CpS.Length + Bonuses.Length] = bool2float;
            td.Add($"Bonuses[{i}] = {bool2float}");
        }

        td.Add("effects begin");
        for (int i = 0; i < Adds.Count; i++)
        {
            td.Add(Adds[i]);
        }
        td.Add("effects end");

        File.WriteAllLines(path + "settings.ini", td.ToArray());

        Read();
    }

    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
