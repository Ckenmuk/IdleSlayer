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
    public List<string> effects;

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
            path = Application.persistentDataPath + "/";
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

    }

    private void WriteDefault()
    {
        List<string> td = new List<string>();

        td.Add("coins = 0");
        td.Add("cps = 0");
        td.Add("minCps = 0");

        td.Add("effects begin");
        for (int i = 0; i < effects.Count; i++)
        {
            td.Add(effects[i]);
        }
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

        td.Add("effects begin");
        for (int i = 0; i < effects.Count; i++)
        {
            td.Add(effects[i]);
        }
        td.Add("effects end");

        File.WriteAllLines(path + "settings.ini", td.ToArray());

        Read();
    }
}
