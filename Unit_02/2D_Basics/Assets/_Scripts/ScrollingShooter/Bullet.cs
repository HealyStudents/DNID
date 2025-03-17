using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = speed;

        if (transform.position.x > 20f)
        {
            BulletPooler.instance.DestroyBullet(gameObject);
        }
    }
}
