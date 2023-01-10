using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IControllable
{
    [SerializeField] private float _maxSpeed = 15f;
    [SerializeField] private float _accelerate = 25f;
    [SerializeField] private float _jumpForge = 30f;
    [SerializeField] private float _forgeDown = 15f;
    [SerializeField] private float _distanceBurst = 13f;

    private MovementDirectionX _movementDirectionX;
    private Jump _jump;
    private Down _down;
    private Burst _burst;
    private Rigidbody2D _rigidbody2D;
    private Stamina _stamina;

    private void Awake()
    {
        _stamina = GetComponent<Stamina>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movementDirectionX = new MovementDirectionX(_maxSpeed, _accelerate, _rigidbody2D);
        _jump = new Jump(_jumpForge, _rigidbody2D);
        _down = new Down(_forgeDown, _rigidbody2D);
        _burst = new Burst(_distanceBurst, transform);
    }

    public void Burst(float directionX)
    {
        if (_stamina.IsExist)
        {
            StartCoroutine(_burst.StartBurst(directionX));
            _stamina.Spend();
        }
    }

    public void Down()
    {
        if (_stamina.IsExist)
        {
            _down.StartDown();
            _stamina.Spend();
        }
    }

    public void Jump()
    {
        _jump.StartJump();
    }

    public void Move(float directoinX)
    {
        _movementDirectionX.Move(directoinX);
    }

    public void ImproveSpeed(float newMaxSpeed)
    {
        _movementDirectionX.ImproveSpeed(newMaxSpeed);
    }

}
