using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private MoneyManager MoneyManager;

    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private float directionX;

    private float bronzeCoinsCost = 1.0f;
    private float silverCoinsCost = 10.0f;
    private float goldCoinsCost = 100.0f;
    private float enemyMult = .01f;
    private float bossMult = .1f;
    private float swordMult = -1.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        playerDirection = new Vector2(directionX, 0).normalized;
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, 0);

        if (rb.position.x < 0)
        {
            rb.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
        }
        else
        {
            rb.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            MoneyManager.Multipier(enemyMult);
        }
        else if (collision.tag == "Boss")
        {
            MoneyManager.Multipier(bossMult);
        }
        else if (collision.tag == "Sword")
        {
            MoneyManager.Multipier(swordMult);
        }
        else if (collision.tag == "BronzeCoin")
        {
            MoneyManager.AddCoins(bronzeCoinsCost);
        }
        else if (collision.tag == "SilverCoin")
        {
            MoneyManager.AddCoins(silverCoinsCost);
        }
        else if (collision.tag == "GoldCoin")
        {
            MoneyManager.AddCoins(goldCoinsCost);
        }
    }
}
