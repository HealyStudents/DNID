using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.up * speed);
        }
    }
}
