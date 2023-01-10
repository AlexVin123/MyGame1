using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDirectionX : IControllerAbillities
{
    private float _maxSpeed;
    private float _accelerate;
    private Rigidbody2D _rigidbody2D;
    private float _speed;
    private float _targetSpeed;

    public MovementDirectionX(float maxSpeed, float accelerate, Rigidbody2D rigidbody2D)
    {
        _maxSpeed = maxSpeed;
        _accelerate = accelerate;
        _rigidbody2D = rigidbody2D;
    }
    public void Close()
    {
    }

    public void Open()
    {

    }

    public void Move(float directionX)
    {
        _targetSpeed = _maxSpeed * directionX;
        _speed = Mathf.Lerp(_speed, _targetSpeed, _accelerate * Time.deltaTime);
        _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
    }

    public void ImproveSpeed(float newMaxSpeed)
    {
        _maxSpeed = newMaxSpeed;
    }

}
