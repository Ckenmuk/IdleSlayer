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
                    moneyManager.GainCpS(1.02f);
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

                default:
                    break;
            }
            Destroy(gameObject);
        }
        
    }
}
