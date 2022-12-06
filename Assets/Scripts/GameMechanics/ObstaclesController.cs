using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    private float speed = 10;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, -speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Border")
        {
            Destroy(gameObject);
        }

        if(collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
