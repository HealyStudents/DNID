using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = BulletPooler.instance.GetBullet();
            newBullet.transform.position = transform.position;
            newBullet.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed, Space.World);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.up * speed, Space.World);
        }
    }
}
