using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //get input from the user
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 8f)
        {
            transform.Translate(new Vector3(movementSpeed, 0f, 0f));
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -8f)
        {
            transform.Translate(new Vector3(-movementSpeed, 0f, 0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //move position directly
        //transform.position = transform.position + new Vector3(0.1f, 0f, 0f);

        //move with translate
        //transform.Translate(new Vector3(0.01f, 0f, 0f));


        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if this is a bomb
        if (collision.collider.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
