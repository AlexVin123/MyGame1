using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _accelerate;
    [SerializeField] private float _forgeJump;

    private float _speed;
    private Rigidbody2D _rigidbody2D;
    private PlayerInput _input;
    private float _directionX;
    private float _lastDirectionX;
    private bool _isFlip;

    private void Awake()
    {
        _input = new PlayerInput();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input.PlayerMovement.Jump.performed += etc => OnJump();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        _directionX = _input.PlayerMovement.MoveX.ReadValue<float>();

        if (_directionX != 0 && _isFlip)
            _lastDirectionX = _directionX;

        Debug.Log(_rigidbody2D.velocity.x + "|||" + _speed);

        Move();
    }

    private void Move()
    {
        if (_directionX != 0 && _isFlip)
        {
        _speed = Mathf.Lerp(_speed, _maxSpeed, _accelerate * Time.deltaTime);
            _rigidbody2D.velocity = new Vector2(_speed * _directionX, _rigidbody2D.velocity.y);
        }
        else
        {
            _isFlip = false;
            _speed = Mathf.Lerp(_speed, 0, _accelerate * Time.deltaTime);
            _rigidbody2D.velocity = new Vector2(_speed * _lastDirectionX, _rigidbody2D.velocity.y);

            if (_speed < 0.1)
            {
                _speed = 0;
                _lastDirectionX = 0;
                _isFlip = true;
            }
        }
    }

    private void OnJump()
    {
        Jump();
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(transform.up * _forgeJump, ForceMode2D.Impulse);
    }
}
