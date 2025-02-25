using UnityEngine;
using System.Collections;

public class Bomber : MonoBehaviour
{
    public GameObject bombPrefab;
    private bool movingRight;
    public float bomberSpeed, bombWaitTime;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(BombCoroutine());
    }

    void FixedUpdate()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * bomberSpeed); // new Vector3(1f, 0f, 0f);
            if (transform.position.x > 8f) movingRight = false;
        }
        else
        {
            transform.Translate(-Vector3.right * bomberSpeed);
            if (transform.position.x < -8f) movingRight = true;
        }
    }

    IEnumerator BombCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(bombWaitTime);

            anim.SetTrigger("Throw");

            yield return new WaitForSeconds(0.4f);

            SpawnBomb();
        }
    }

    private void SpawnBomb()
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }
}
