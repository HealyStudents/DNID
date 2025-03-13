using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _xVelocity;
    private Animator _anim;
    private SpriteRenderer _rend;
    private bool _grounded;

    public float speed, jumpSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _rend = GetComponent<SpriteRenderer>();
    }

    //Get Input in Update
    private void Update()
    {
        if (PauseMenu.instance.isPaused) return;

        _xVelocity = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    private bool IsGrounded()
    {
        return _grounded;
    }

    private void Jump()
    {
        _rb.linearVelocityY = jumpSpeed;
        _grounded = false;
    }

    //Do something with the input in FixedUpdate
    private void FixedUpdate()
    {
        if (PauseMenu.instance.isPaused)
        {
            _rb.simulated = false;
            _anim.enabled = false;
            return;
        }
        else
        {
            _anim.enabled = true;
            _rb.simulated = true;
        }

        _anim.SetBool("Walking", _xVelocity != 0);
        _anim.SetBool("Grounded", IsGrounded());

        _rb.linearVelocityX = _xVelocity * speed;

        _rend.flipX = (_xVelocity < 0 || (_xVelocity == 0 && _rend.flipX));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && _rb.linearVelocityY == 0)
        {
            _grounded = true;
        }
    }
}
