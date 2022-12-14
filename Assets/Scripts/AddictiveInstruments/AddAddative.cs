using UnityEngine;

public class AddAddative : MonoBehaviour
{
    public string title;
    public float value;
    public float cost;
    
    public void ClickAdd()
    {
        ObstaclesSpawn obstaclesSpawn = FindObjectOfType<ObstaclesSpawn>();
        MoneyManager moneyManager = FindObjectOfType<MoneyManager>();
        Player player = FindObjectOfType<Player>();
        ImproveManager improveManager = FindObjectOfType<ImproveManager>();

        if (moneyManager.coins >= cost)
        {
            moneyManager.AddCoins(-cost);
            switch (title)
            {
                case "Add 1":
                    obstaclesSpawn.CoinsSpawnDelay(value);
                    break;
                case "Add 2":
                    moneyManager.GainCpS(value);
                    break;
                case "Add 3":
                    obstaclesSpawn.EnemiesOn();
                    break;
                case "Add 4":
                    obstaclesSpawn.SilverCoinsOn();
                    break;
                case "Add 5":
                    moneyManager.GainCpS(value);
                    break;
                case "Add 6":
                    obstaclesSpawn.BossesOn();
                    break;
                case "Add 7":
                    player.CoinsCost(value);
                    break;
                case "Add 8":
                    obstaclesSpawn.EnemiesSpawnDelay(value);
                    break;
                case "Add 9":
                    obstaclesSpawn.BonusesOn();
                    break;
                case "Add 10":
                    moneyManager.GainCpS(value);
                    break;
                case "Add 11":
                    obstaclesSpawn.CoinsSpawnDelay(value);
                    break;
                case "Add 12":
                    obstaclesSpawn.GoldCoinsOn();
                    break;
                case "Add 13":
                    obstaclesSpawn.EnemiesSpawnDelay(value);
                    break;
                case "Add 14":
                    player.CoinsCost(value);
                    break;
                case "Add 15":
                    obstaclesSpawn.InvulnerabilityOn();
                    break;
                case "Add 16":
                    moneyManager.GainCpS(value);
                    break;
                case "Add 17":
                    moneyManager.IfGameClosed();
                    break;
                case "Add 18":
                    improveManager.WeaponUpgrade(value);
                    break;

                default:
                    break;
            }
            Destroy(gameObject);
        }
        
    }
}
