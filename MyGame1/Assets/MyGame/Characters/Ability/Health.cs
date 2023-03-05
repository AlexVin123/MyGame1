using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float _health;
    private int _maxHealth;

    public bool IsDie => _health == 0;

    public Health(int maxHealth)
    {
        _maxHealth = maxHealth;
        _health = maxHealth;
    }

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
