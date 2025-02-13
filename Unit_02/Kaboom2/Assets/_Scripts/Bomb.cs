using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            GameManager.instance.KillPlayer();
            Destroy(gameObject);
        }
    }
}
