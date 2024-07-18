using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private Transform _levelStartTransform;
    [SerializeField] private TextMeshProUGUI _playerLivesText;
    [SerializeField] private GameObject _gameOverUI;

    private ScoreController _scoreController;
    private Rigidbody2D _rigidBody;

    private bool _isGrounded = true;
    private bool _isAlive = true; 

    private float _jumpForce = 8.0f;
    private float _moveSpeed = 10.0f;

    private int _playerLives = 3;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _scoreController = GameObject.Find("Score").GetComponent<ScoreController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = _levelStartTransform.position;
        _playerLivesText.text = "Lives: " + _playerLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAlive)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Crouch();
            }
            else
            {
                _anim.SetBool("Crouch", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                Jump();
            }
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

    public void PickUpKey()
    {
        _scoreController.IncrementScore(1);
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
            _isAlive = false;
            _playerLives = 0;

            _anim.SetTrigger("Death");
        }
        else if (other.gameObject.GetComponent<EnemyController>())
        {
            if (_isAlive)
            {
                _playerLives--;
                _playerLivesText.text = "Lives: " + _playerLives.ToString();
            }

            if (_playerLives == 0)
            {
                _isAlive = false;

                _anim.SetTrigger("Death");
                _gameOverUI.SetActive(true);
            }
        }
    }
}
