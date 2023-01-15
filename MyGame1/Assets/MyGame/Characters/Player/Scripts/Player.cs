using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IControllable
{
    private DataBasePlayer _dataBasePlayer;

    private List<Ability> abilities;

    private MovementDirectionX _movementDirectionX;
    private Jump _jump;
    private BurstDown _down;
    private Burst _burst;
    private Rigidbody2D _rigidbody2D;
    private Stamina _stamina;
    private DefenitionCollisions _defenitionCollisions;

    public void Init()
    {
        abilities = new List<Ability>();
        _defenitionCollisions = GetComponent<DefenitionCollisions>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movementDirectionX = new MovementDirectionX(_dataBasePlayer, _rigidbody2D);
        _jump = new Jump(_dataBasePlayer, _rigidbody2D);
        _burst = new Burst(_dataBasePlayer, _rigidbody2D);
        _stamina = new Stamina(_dataBasePlayer, _rigidbody2D);
        _down = new BurstDown(_dataBasePlayer, _rigidbody2D);
        abilities.Add(_movementDirectionX);
        abilities.Add(_jump);
        abilities.Add(_burst);
        abilities.Add(_stamina);
        abilities.Add(_down);

        foreach (var ability in abilities)
        {
            ability.SetParameter();
        }
    }

    public void SerDataBase(DataBasePlayer dataBasePlayer)
    {
        _dataBasePlayer = dataBasePlayer;
    }

    public void Burst(float directionX)
    {
        if (_stamina.IsExist)
        {
            StartCoroutine(_burst.StartBurst(directionX));
            _stamina.Spend();
            StartCoroutine(_stamina.Timer());
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
        _jump.StartJump(_defenitionCollisions);
    }

    public void Move(float directoinX)
    {
        _movementDirectionX.Move(directoinX);
    }
}
