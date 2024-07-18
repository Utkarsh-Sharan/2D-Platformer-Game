using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerController : EnemyController
{
    private Vector2 _currentPosition;
    private float _speed = 2.0f;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        if(_rigidBody == null)
        {
            Debug.LogError("Rigid body is null!");
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer == null)
        {
            Debug.LogError("Sprite Renderer is null!");
        }

        _currentPosition = wayPoint1.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        SetCurrentPosition();
    }

    void Movement()
    {
        if (_currentPosition.x == wayPoint1.position.x)
        {
            _rigidBody.velocity = new Vector2(_speed, 0);
            _spriteRenderer.flipX = true;
        }
        else if (_currentPosition.x == wayPoint2.position.x)
        {
            _rigidBody.velocity = new Vector2(-_speed, 0);
            _spriteRenderer.flipX = false;
        }
    }

    void SetCurrentPosition()
    {
        if (Vector2.Distance(_currentPosition, transform.position) < 0.5f && _currentPosition.x == wayPoint1.position.x)
        {
            _currentPosition.x = wayPoint2.position.x;
        }
        else if (Vector2.Distance(_currentPosition, transform.position) < 0.5f && _currentPosition.x == wayPoint2.position.x)
        {
            _currentPosition.x = wayPoint1.position.x;
        }
    }
}
