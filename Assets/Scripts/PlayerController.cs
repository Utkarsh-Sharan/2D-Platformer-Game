using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private Transform _levelStartTransform;

    private Rigidbody2D _rigidBody;
    private bool _isGrounded = true;

    private float _jumpForce = 5.0f;
    private float _moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        transform.position = _levelStartTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
        else
        {
            _anim.SetBool("Crouch", false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        MoveAnimation(horizontalInput);

        Vector2 position = transform.position;
        position.x += horizontalInput * _moveSpeed * Time.deltaTime;
        transform.position = position;
    }

    private void MoveAnimation(float horizontalInput)
    {
        _anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
        Vector2 _scale = transform.localScale;

        if (horizontalInput < 0)
        {
            _scale.x = -1.0f * Mathf.Abs(_scale.x);
        }
        else if (horizontalInput > 0)
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
        else if (other.gameObject.CompareTag("DeathPlatform"))
        {
            _anim.SetTrigger("Death");
        }
    }
}
