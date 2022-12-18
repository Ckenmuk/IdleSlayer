using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private MoneyManager MoneyManager;

    [SerializeField] private GameObject InvSphere;
    [SerializeField] private GameObject CpSPlus;
    [SerializeField] private GameObject CoinsPlus;
    [SerializeField] private GameObject PlayerSprite;

    [SerializeField] GameObject SwipeScanner;

    private float playerSpeed = 50;

    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private float directionX = -1;

    public bool swordHit;
    public bool hit;
    public bool inv;
    public bool coinsPlus;

    public float coinsCost = 1.0f;
    private float enemyMult = 0.01f;
    private float bossMult = .1f;
    private float swordMult = -1.0f;
    private float meteorMult;
    private float invulnerability = 1;


    public void CoinsCost(float value)
    {
        coinsCost *= value;
    }

    private void CpSCollect()
    {
        CpSPlus.SetActive(true);
        Invoke(nameof(CpSMinus), .2f);
    }

    private void CpSMinus()
    {
        CpSPlus.SetActive(false);
    }

    private void CoinsCollect()
    {
        CoinsPlus.SetActive(true);
        Invoke(nameof(CoinsMinus), .2f);
    }

    private void CoinsMinus()
    {
        CoinsPlus.SetActive(false);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        GetComponent<Animator>().SetBool("OnHit", hit);
        GetComponent<Animator>().SetBool("coinsPlus", coinsPlus);
        GetComponent<Animator>().SetBool("swordHit", swordHit);

        InvSphere.SetActive(inv);




        if (SwipeScanner.activeInHierarchy)
        {
            if (FindObjectOfType<SwipeController>().dir > 0 || Input.GetKey(KeyCode.D))
            {
                directionX = 1;
            }
            if (FindObjectOfType<SwipeController>().dir < 0 || Input.GetKey(KeyCode.A))
            {
                directionX = -1;
            }
        }

        playerDirection = new Vector2(directionX, 0).normalized;
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, 0);

        transform.localPosition = new Vector3(transform.localPosition.x, -5f, 0);

        if (rb.transform.localPosition.x < 0)
        {
            PlayerSprite.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
        }
        else
        {
            PlayerSprite.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
        
        

        meteorMult = -2 * MoneyManager.cps;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Enemy":
                MoneyManager.Multipier(enemyMult, true);
                hit = true;
                CpSCollect();
                break;
            case "Boss":
                MoneyManager.Multipier(bossMult, true);
                hit = true;
                CpSCollect();
                break;
            case "Sword":
                MoneyManager.Multipier(swordMult * invulnerability, false);
                swordHit = true;
                break;
            case "Meteor":
                MoneyManager.Multipier(meteorMult * invulnerability, false);
                break;
            case "BronzeCoin":
                MoneyManager.AddCoins(coinsCost);
                CoinsCollect();
                break;
            case "SilverCoin":
                MoneyManager.AddCoins(10 * coinsCost);
                CoinsCollect();
                break;
            case "GoldCoin":
                MoneyManager.AddCoins(100 * coinsCost);
                CoinsCollect();
                break;
            case "Chest":
                int i = 1;
                for (int j = 1; j < 4; j++)
                {
                    if (Random.Range(0, (float)System.Math.Pow(10, j)) < (float)System.Math.Pow(10, j - 1))
                    {
                        i = j;
                        break;
                    }
                }
                MoneyManager.Bonuses(i);
                break;
            case "Invulnerability":
                invulnerability = 0;
                inv = true;
                Invoke(nameof(ResetInvulnerability), 10.0f);
                    break;
            default:
                break;
        }
    }

    private void ResetCpSPlus()
    {
        
    }


    private void ResetInvulnerability()
    {
        invulnerability = 1;
        inv = false;
    }
}
