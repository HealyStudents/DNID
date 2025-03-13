using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DieSoon());
    }

    IEnumerator DieSoon()
    {
        yield return new WaitForSeconds(0.5f);
        while (GameManager.instance.isPaused) yield return new WaitForFixedUpdate();
        Destroy(gameObject);
    }
}
