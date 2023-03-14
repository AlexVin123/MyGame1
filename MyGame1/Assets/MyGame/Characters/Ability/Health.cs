using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Ability
{
    private float _health;
    private float _maxHealth;

    public float CurrentHealth => _health;

    public bool IsDie => _health == 0;

    public void Heal(float value)
    {
        if(_health + value > _maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            _health += value;
        }
    }

    public override void Init(DataBase dataPlayer)
    {
        _maxHealth = float.Parse(dataPlayer.GetParameter(TypeParameter.MaxHealth));
        _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if(_health > damage)
        {
            _health -= damage;
        }
        else
        {
            _health = 0;
        }
    }
}
