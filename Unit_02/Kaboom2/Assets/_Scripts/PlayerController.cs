using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera gameCamera;
    public float movementSpeed;

    private void Awake()
    {
        gameCamera = Camera.main;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        /*Button input method
        //get input from the user
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 8f)
        {
            transform.Translate(new Vector3(movementSpeed, 0f, 0f));
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -8f)
        {
            transform.Translate(new Vector3(-movementSpeed, 0f, 0f));
        }
        */

        if (GameManager.instance.isPaused) return;

        // Mouse position input method  
        float mouseX = gameCamera.ScreenToWorldPoint(Input.mousePosition).x;
        transform.position = new Vector2(mouseX, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if this is a bomb
        if (collision.collider.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.collider.gameObject);
            GameManager.instance.CatchBomb();

            //find the top bucket 
            GameObject topBucket = transform.GetChild(transform.childCount - 1).gameObject;
            //Trigger the splash animation
            topBucket.GetComponent<Animator>().SetTrigger("CaughtBomb");
        }
    }
}
