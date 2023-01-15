using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDirectionX : Ability
{
    private MovementSpeed _maxSpeed;
    private float _accelerate;
    private float _speed;
    private float _targetSpeed;

    public MovementDirectionX(DataBasePlayer dataBasePlayer, Rigidbody2D rb) : base(dataBasePlayer, rb)
    {
        _accelerate = 35f;
    }

    public override void SetParameter()
    {
        _maxSpeed = (MovementSpeed)DataBasePlayer.GetParameter(ParametersPlayer.MaxSpeed);
    }

    public void Move(float directionX)
    {
        _targetSpeed = _maxSpeed.Value * directionX;
        _speed = Mathf.Lerp(_speed, _targetSpeed, _accelerate * Time.deltaTime);
        Rigidbody2D.velocity = new Vector2(_speed, Rigidbody2D.velocity.y);
    }
}
