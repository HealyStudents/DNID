using UnityEngine;
using System.Collections.Generic;

public class BulletPooler : MonoBehaviour
{
    public static BulletPooler instance;
    public int minPoolSize;

    public GameObject bulletPrefab;
    private List<GameObject> inactivePool;

    private void Awake()
    {
        instance = this;
        inactivePool = new List<GameObject>();
    }

    void Start()
    {
        for(int i = 0; i < minPoolSize; i++) 
        {
            GameObject ob = Instantiate(bulletPrefab, transform);
            ob.SetActive(false);
            inactivePool.Add(ob);
        }
    }

    public GameObject GetBullet()
    {
        GameObject ob = null;
        if (inactivePool.Count == 0)
        {
            ob = Instantiate(bulletPrefab, transform);
            ob.SetActive(false);
        }
        else
        {
            ob = inactivePool[0];
            inactivePool.RemoveAt(0);
            ob.SetActive(false);
        }

        return ob;
    }

    public void DestroyBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        inactivePool.Add(bullet);
    }
}
