using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IControllable
{
    private DataBasePlayer _characterData;
    private MovementDirectionX _movementDirectionX;
    private Jump _jump;
    private BurstDown _down;
    private Burst _burst;
    private Rigidbody2D _rigidbody2D;
    private Stamina _stamina;
    private DefenitionCollisions _defenitionCollisions;
    private Health _health;

    public void Init()
    {
        _characterData.Chainge.AddListener(Init);
        _defenitionCollisions = GetComponent<DefenitionCollisions>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movementDirectionX = new MovementDirectionX(_characterData.MaxSpeed, _rigidbody2D);
        _jump = new Jump(_characterData.ForgeJump, _rigidbody2D);
        _burst = new Burst(_characterData.DictanceBurst, _rigidbody2D);
        _stamina = new Stamina(_characterData.CountStamina, _characterData.DelayStamina, _rigidbody2D);
        _down = new BurstDown(_rigidbody2D);
        _health = new Health(_characterData.MaxHealth);

    }

    public void SetDataBase(DataBasePlayer dataBasePlayer)
    {
        _characterData = dataBasePlayer;
    }

    public void Burst(float directionX)
    {
        if (_stamina.IsExist)
        {
            StartCoroutine(_burst.StartBurst(directionX));
            _stamina.Spend();
            StartCoroutine(_stamina.Timer());
            Debug.Log("UUUU");
        }
    }

    public void Down()
    {
        if (_stamina.IsExist)
        {
            _down.StartDown();
            _stamina.Spend();
            StartCoroutine(_stamina.Timer());
        }
    }

    public void Jump()
    {
        if (_defenitionCollisions.IsGround)
            _jump.StartJump(_defenitionCollisions);
    }

    public void Move(float directoinX)
    {
        _movementDirectionX.Move(directoinX);
    }
}
