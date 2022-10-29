using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        playerDirection = new Vector2(directionX, 0).normalized;
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, 0);

 /*       if (rb.position.x < 0)
        {
            rb.rotation = 0.0f;
        }
        else
        {
            rb.rotation = 180.0f;
        }
  */
    }

    private void FixedUpdate()
    {

    }
}
