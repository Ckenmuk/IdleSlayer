using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public float coins;
    public float cps;

    public string path;

    [System.Obsolete]
    void Start()
    {
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
        string[] data = File.ReadAllLines(path + "settings.ini");
        coins = (float)(double.Parse(data[0].Remove(0, data[0].IndexOf("=") + 2)));
        cps = (float)(double.Parse(data[1].Remove(0, data[1].IndexOf("=") + 2)));
    }

    private void WriteDefault()
    {
        List<string> td = new List<string>();
        td.Add("Coins = 0");
        td.Add("CpS = 0");

        File.WriteAllLines(path + "settings.ini", td.ToArray());

        Read();
    }

    public void WriteNewSettings()
    {
        List<string> td = new List<string>();
        td.Add("Coins = " + coins);
        td.Add("CpS = " + cps);

        File.WriteAllLines(path + "settings.ini", td.ToArray());

        Read();
    }
}
