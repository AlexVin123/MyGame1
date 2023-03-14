using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDirectionX : AbilityRB
{
    [SerializeField]private float _accelerate = 40;
    private float _maxSpeed;
    private float _speed;
    private float _targetSpeed;

    public override void Init(DataBase dataPlayer)
    {
        base.Init(dataPlayer);
        _maxSpeed = float.Parse(dataPlayer.GetParameter(TypeParameter.MaxSpeedMovement));
    }

    public void Move(float directionX)
    {
        _targetSpeed = _maxSpeed * directionX;
        _speed = Mathf.Lerp(_speed, _targetSpeed, _accelerate * Time.deltaTime);
        Rigidbody.velocity = new Vector2(_speed, Rigidbody.velocity.y);
    }
}
