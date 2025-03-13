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
        if (GameManager.instance.isPaused) return;

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
            while (GameManager.instance.isPaused) yield return new WaitForFixedUpdate();

            yield return new WaitForSeconds(bombWaitTime);

            while (GameManager.instance.isPaused) yield return new WaitForFixedUpdate();
            anim.SetTrigger("Throw");

            yield return new WaitForSeconds(0.4f);

            while (GameManager.instance.isPaused) yield return new WaitForFixedUpdate();

            SpawnBomb();
        }
    }

    private void SpawnBomb()
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }
}
