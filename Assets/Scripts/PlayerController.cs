using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    private Rigidbody2D _rigidBody;
    private bool _isGrounded = true;
    private float _jumpForce = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }

        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    private void Move()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        _anim.SetFloat("Speed", Mathf.Abs(speed));
        Vector2 _scale = transform.localScale;

        if (speed < 0)
        {
            _scale.x = -1.0f * Mathf.Abs(_scale.x);
        }
        else if (speed > 0)
        {
            _scale.x = Mathf.Abs(_scale.x);
        }

        transform.localScale = _scale;
    }

    private void Crouch()
    {
        _anim.SetBool("Crouch", true);
    }

    private void Jump()
    {
        _isGrounded = false;

        _anim.SetBool("Jump", true);

        _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            _isGrounded = true;
            _anim.SetBool("Jump", false);
        }
    }
}
