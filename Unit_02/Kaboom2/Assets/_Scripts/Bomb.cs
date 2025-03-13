using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.simulated = !GameManager.instance.isPaused;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            GameManager.instance.KillPlayer();
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
