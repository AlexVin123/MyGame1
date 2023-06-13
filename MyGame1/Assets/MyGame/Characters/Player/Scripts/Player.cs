using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Stamina))]
[RequireComponent(typeof(Burst))]
[RequireComponent(typeof(BurstDown))]
[RequireComponent(typeof(Jump))]
[RequireComponent(typeof(MovementDirectionX))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof (Explosion))]
[RequireComponent(typeof(Aim))]
[RequireComponent(typeof(DefenitionCollisions))]
public class Player : DamageableObject, IControllable
{
    [SerializeField] private Transform _torso;
    [SerializeField] private Transform _leg;

    private ICharacterConfig _parameters;
    private PlayerParameters _parameters2;

    private Weapon _weapon;

    private ParticalController _particalController;

    private DefenitionCollisions _defenitionCollisions;
    private Stamina _stamina;
    private Burst _burst;
    private BurstDown _burstDown;
    private MovementDirectionX _movementDirectionX;
    private Jump _jump;
    private Explosion _explosion;
    private Aim _aim;
    private Vector2 _luckDirection;

    public UnityAction<float, float> ChaigeLoadStaminaPoint { get { return _stamina.ChaigedLoad; } set { _stamina.ChaigedLoad = value; } }
    public UnityAction<int> ChaigedStaminaCount { get { return _stamina.ChaigeCount; } set { _stamina.ChaigeCount = value; } }
    public UnityAction<int> AddedStaminaCount { get { return _stamina.Added; } set { _stamina.Added = value; } }

    public override Vector2 LuckDirection => _luckDirection;

    public int CountStamina => _stamina.MaxCout;

    private void OnDisable()
    {
        _burstDown.StartBurstDowm -= OnBurstDownStart;
        _explosion.StartExploson -= OnBurstDownStop;
        _explosion.StartExploson -= OnExplousionStart;
    }

    public void Aim(Vector2 mousePosition)
    {
         _luckDirection = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        _aim.AimTarget(_luckDirection);
        Flip(mousePosition);
    }

    public override void Init(ICharacterConfig config)
    {
        base.Init(config);
        SetParameters(config);
        GetComponents();
        _movementDirectionX.Init(_parameters);
        _burst.Init(_parameters);
        _burstDown.Init(_parameters);
        _jump.Init(_parameters);
        _explosion.Init(_parameters);
        _weapon.Init(_parameters);
        _aim.Init(_torso);
        Health.Init(_parameters);
        _stamina.Init(_parameters);
        _defenitionCollisions.Init();
        _burstDown.StartBurstDowm += OnBurstDownStart;
        _explosion.StartExploson += OnBurstDownStop;
        _explosion.StartExploson += OnExplousionStart;
    }

    public void OnUpgradeParameter()
    {
        Debug.Log("ўбнова");
        ResetParam();
    }

    public override void ResetParam()
    {
        Health.Init(_parameters);
        _stamina.Init((_parameters));
        _weapon.Init(_parameters);
        _movementDirectionX.Init(_parameters);
        _burst.Init(_parameters);
        _burstDown.Init(_parameters);
        _jump.Init(_parameters);
        _explosion.Init(_parameters);
    }

    public void SetParameters(ICharacterConfig parameters)
    {
        _parameters = parameters;
        _parameters2 = (PlayerParameters)parameters;
    }

    public void Burst(Vector2 direction)
    {
        if (direction.x != 0)
        {
            if (_stamina.IsExist)
            {
                _burst.Perform(direction);
                _stamina.Spend();
            }
        }
    }

    public void Down()
    {
        if(_defenitionCollisions.GroundCheck() == false)
        {
            if (_stamina.IsExist)
            {
                _burstDown.Perform();
                _stamina.Spend();
            }
        }

    }

    public void Jump()
    {
        if (_defenitionCollisions.GroundCheck())
            _jump.Perform();
    }

    public void Move(Vector2 directoin)
    {
        _movementDirectionX.Perform(directoin);
    }

    public void Shoot()
    {
        _weapon.Shoot();
    }

    private void GetComponents()
    {
        _aim = GetComponent<Aim>();
        _movementDirectionX = GetComponent<MovementDirectionX>();
        _stamina = GetComponent<Stamina>();
        _defenitionCollisions = GetComponent<DefenitionCollisions>();
        _particalController = GetComponent<ParticalController>();
        _jump = GetComponent<Jump>();
        _burst = GetComponent<Burst>();
        _burstDown = GetComponent<BurstDown>();
        _weapon = GetComponentInChildren<Weapon>();
        _explosion = GetComponent<Explosion>(); 
    }

    private void Flip(Vector2 mousePosition)
    {
        Vector2 positionPlayer = Camera.main.WorldToScreenPoint(transform.position);
        if(positionPlayer.x > mousePosition.x)
        {
            _torso.localScale = new Vector2(1, -1);
            _leg.localScale = new Vector2(-1, 1);
        }
        else
        {
            _torso.localScale = new Vector2(1, 1);
            _leg.localScale = new Vector2(1, 1);
        }
    }

    private void OnBurstDownStart()
    {
        _particalController.PlayPartical(0);
    }

    private void OnBurstDownStop()
    {
        _particalController.Stop(0);
    }

    private void OnExplousionStart()
    {
        _particalController.PlayPartical(1);
    }
}
