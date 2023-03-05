using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDirectionX : Ability
{
    private float _maxSpeed;
    private float _accelerate;
    private float _speed;
    private float _targetSpeed;

    public MovementDirectionX(float maxSpeed, Rigidbody2D rb) : base(rb)
    {
        _maxSpeed = maxSpeed;
        _accelerate = 35f;
    }

    public void Move(float directionX)
    {
        Debug.Log("MaxSpeed:" + _maxSpeed);
        _targetSpeed = _maxSpeed * directionX;
        _speed = Mathf.Lerp(_speed, _targetSpeed, _accelerate * Time.deltaTime);
        Rigidbody2D.velocity = new Vector2(_speed, Rigidbody2D.velocity.y);
    }
}
