using System.Collections.Generic;
using UnityEngine;

public class TriggerEnableObjects : MonoBehaviour
{
    public List<GameObject> objects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            foreach(GameObject obj in objects) 
            {
                obj.SetActive(true);
            }
        }
    }
}
