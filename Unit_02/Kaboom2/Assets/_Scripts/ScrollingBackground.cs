using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private Vector3 spawnPos;
    public float distance, scrollSpeed;


    void Start()
    {
        spawnPos = transform.GetChild(1).position;
        distance = Vector3.Distance(transform.GetChild(0).position, transform.GetChild(1).position) * 2;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);
            t.Translate(-transform.right * scrollSpeed);
            if (Vector3.Distance(t.position, spawnPos) > distance)
            {
                t.position = spawnPos;
            }
        }
    }
}
