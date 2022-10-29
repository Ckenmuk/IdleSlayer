using UnityEngine;

public class ObstaclesColliding : MonoBehaviour
{
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
