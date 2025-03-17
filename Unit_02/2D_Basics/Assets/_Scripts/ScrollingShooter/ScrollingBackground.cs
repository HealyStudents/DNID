using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private Vector3 spawnPos;
    public float distance, scrollSpeed;


    void Start()
    {
        spawnPos = transform.GetChild(1).position;
        distance = Vector3.Distance(transform.GetChild(0).position, transform.GetChild(1).position);
    }

    private void FixedUpdate()
    {
        //move everything
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);
            t.Translate(-transform.right * scrollSpeed);
        }

        //check if we should reset the pos
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);
            if (Vector3.Distance(t.position, spawnPos) > distance * 2)
            {
                t.position = transform.GetChild((i + 1) % transform.childCount).position + transform.right * distance;
            }
        }
    }
}
