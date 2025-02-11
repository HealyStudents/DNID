using UnityEngine;
using System.Collections;

public class Bomber : MonoBehaviour
{
    public GameObject bombPrefab;
    private bool movingRight;
    public float bomberSpeed, bombWaitTime;

    private void Start()
    {
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

            SpawnBomb();
        }
    }

    private void SpawnBomb()
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }
}
