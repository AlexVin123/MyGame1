using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rFly : AbilityRB
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _accelerate;

    private Vector2 _speed;
    private Vector2 _targetSpeed;

    public override void Init(ICharacterConfig parameters)
    {
        base.Init(parameters);
    }

    public override void Perform (Vector2 direction)
    {
        _targetSpeed.x = _maxSpeed * direction.x;
        _targetSpeed.y = _maxSpeed * direction.y;
        _speed.x = Mathf.Lerp(_speed.x, _targetSpeed.x, _accelerate * Time.deltaTime);
        _speed.y = Mathf.Lerp(_speed.y, _targetSpeed.y, _accelerate * Time.deltaTime);
        Rigidbody.velocity = _speed;
    }
}
