using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Stamina))]
[RequireComponent(typeof(Burst))]
[RequireComponent(typeof(BurstDown))]
[RequireComponent(typeof(Jump))]
[RequireComponent(typeof(MovementDirectionX))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IControllable, ITarget
{
    [SerializeField] private Transform _torso;
    [SerializeField] private Transform _leg;
    [SerializeField] private PlayerParameters _parameters;

    private Dictionary<Type, Ability> _abilities;
    private Stamina _stamina;
    private DefenitionCollisions _defenitionCollisions;
    private Health _health;
    private Weapon _weapon;

    public void Aim(Vector2 mousePosition)
    {
        Vector2 lookDirection = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        _torso.rotation = Quaternion.Euler(0, 0, angle);
        Flip(mousePosition);
    }

    public void Init()
    {
        InitAbility();
        _defenitionCollisions = GetComponent<DefenitionCollisions>();
        _health = GetComponent<Health>();
        _stamina = GetComponent<Stamina>();
        ChaigedParameters();
        _weapon = GetComponentInChildren<Weapon>();
        StaminaUI staminaUI = GameObject.FindAnyObjectByType<StaminaUI>();
        staminaUI.Init(_stamina.MaxCout);
    }

    public void ChaigedParameters()
    {
        foreach (var item in _abilities.Values)
        {
            item.Init(_parameters);
        }

        _health.Init(_parameters);
        _stamina.Init(_parameters);
    }

    public void SetParameters(PlayerParameters parameters)
    {
        _parameters = parameters;
    }

    private void InitAbility()
    {
        var abilityes = GetComponents<Ability>();
        _abilities = new Dictionary<Type, Ability>();

        foreach (var ability in abilityes)
        {
            ability.Init(_parameters);
            _abilities.Add(ability.GetType(), ability);
        }
    }

    public void Burst(Vector2 direction)
    {
        if (_stamina.IsExist)
        {
            _abilities[typeof(Burst)].Perform(direction);
            _stamina.Spend();
        }
    }

    public void Down()
    {
        if (_stamina.IsExist)
        {
            _abilities[typeof(BurstDown)].Perform();
            _stamina.Spend();
        }
    }

    public void Jump()
    {
        if (_defenitionCollisions.IsGround)
            _abilities[typeof(Jump)].Perform();
    }

    public void Move(Vector2 directoin)
    {
        _abilities[typeof(MovementDirectionX)].Perform(directoin);
    }

    public void Shoot()
    {
        _weapon.Shoot();
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
        EventPlayer.ChaingedHealth?.Invoke(damage,_health.MaxHealth);
        if(_health.CurrentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        EventPlayer.Dying?.Invoke();
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

    public Vector2 Position()
    {
        return transform.position;
    }

    public void Teleport(Transform point)
    {
        transform.position = point.position;
    }
}
