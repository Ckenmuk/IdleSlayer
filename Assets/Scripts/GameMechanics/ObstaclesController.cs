using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    private float speed = 10;
    private Rigidbody2D rb;
    new private AudioSource audio;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
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
            audio.PlayOneShot(audio.clip);
            rb.transform.localPosition = new Vector3(0, -9.0f, 0);
            Destroy(gameObject, 1000);
        }
    }
}
