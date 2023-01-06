using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HumanoidMovements : MonoBehaviour, IControllable
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _accelerate;
    [SerializeField] private float _forgeJump;
    [SerializeField] private float _forgeBurst;
    [SerializeField] private float _distanseBurst;
    [SerializeField] private float _forgeDown;

    private float _directionX;
    private float _speed;
    private float _targetSpeed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _targetPoint;
    private Vector2 _positionStartBurst;
    private bool isBursted = false;

    public HumanoidMovements(float maxSpeed, float accelerate, float forgeJump)
    {
        _maxSpeed = maxSpeed;
        _accelerate = accelerate;
        _forgeJump = forgeJump;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        BurstInitial();
    }

    public void Move(float directionX)
    {
        _directionX = directionX;
        _targetSpeed = _maxSpeed * directionX;
        _speed = Mathf.Lerp(_speed, _targetSpeed, _accelerate * Time.deltaTime);
        _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(new Vector2(0f, 1 * _forgeJump), ForceMode2D.Impulse);
    }

    private void StartBurst()
    {

    }

    public void Burst()
    {
        _rigidbody2D.simulated = false;
        isBursted = true;
        _positionStartBurst = new Vector2(transform.position.x, transform.position.y);
        _targetPoint = new Vector2(transform.position.x + _distanseBurst * _directionX, transform.position.y);
    }

    public void BurstInitial()
    {
        if (isBursted)
            transform.position = Vector2.MoveTowards(transform.position, _targetPoint, _forgeBurst * Time.deltaTime);

        if (Mathf.Round(transform.position.x) == Mathf.Round(_targetPoint.x))
        {
            isBursted = false;
            _rigidbody2D.simulated = true;
        }
    }

    public void Down()
    {
        _rigidbody2D.AddForce(new Vector2(0f, -1 * _forgeDown), ForceMode2D.Impulse);
    }
}
