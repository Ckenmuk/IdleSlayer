using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private MoneyManager MoneyManager;
    [SerializeField] private GameObject InvSphere;


    public bool hit;
    public bool inv;


    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private float directionX;

    private float coinsCost = 1.0f;
    private float enemyMult = .01f;
    private float bossMult = .1f;
    private float swordMult = -1.0f;
    private float meteorMult;
    private float invulnerability = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        GetComponent<Animator>().SetBool("OnHit", hit);

        InvSphere.SetActive(inv);

        if (FindObjectOfType<SwipeController>().dir > 0)
        {
            directionX = 1;
        }
        if (FindObjectOfType<SwipeController>().dir < 0)
        {
            directionX = -1;
        }

        playerDirection = new Vector2(directionX, 0).normalized;
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, 0);

        transform.localPosition = new Vector3(transform.localPosition.x, -3.5f, 0);

        if (rb.position.x < 0)
        {
            rb.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
        }
        else
        {
            rb.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
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
                break;
            case "Boss":
                MoneyManager.Multipier(bossMult, true);
                hit = true;
                break;
            case "Sword":
                MoneyManager.Multipier(swordMult * invulnerability, false);
                break;
            case "Meteor":
                MoneyManager.Multipier(meteorMult * invulnerability, false);
                break;
            case "BronzeCoin":
                MoneyManager.AddCoins(coinsCost);
                break;
            case "SilverCoin":
                MoneyManager.AddCoins(10 * coinsCost);
                break;
            case "GoldCoin":
                MoneyManager.AddCoins(100 * coinsCost);
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

    private void ResetInvulnerability()
    {
        invulnerability = 1;
        inv = false;
    }
}
