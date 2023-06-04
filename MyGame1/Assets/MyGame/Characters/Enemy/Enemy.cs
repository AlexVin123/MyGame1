using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    private List<ITarget> _targets;
    private Dictionary<TypeAbility, Ability> _abilitiesDictionary;
    private SpriteRenderer[] _spriteEnemy;
    private TargetSearch _targetSearch;
    private Health _health;
    private StateMachine _machine;

    public event Action OnDyingEvent;

    private void Update()
    {
        if (CurrentTarget != null && CurrentTarget.Position().x > transform.position.x)
            transform.rotation = new Quaternion(0,0,0,0);
        else
            transform.rotation = new Quaternion(0,180,0,0);
    }

    public ITarget CurrentTarget
    {
        get
        {
            if(_targets != null && _targets.Count != 0)
            {
                return _targets[_targets.Count - 1];
            }

            return null;
        }
    }

    public void PerformAbility(TypeAbility typeAbility)
    {
        _abilitiesDictionary[typeAbility].Perform();
    }

    public void PerformAbility(TypeAbility typeAbility, float directionX)
    {
        _abilitiesDictionary[typeAbility].Perform(directionX);
    }

    public void PerformAbility(TypeAbility typeAbility, Vector2 direction)
    {
        _abilitiesDictionary[typeAbility].Perform(direction);
    }

    public virtual void Init(ITarget target = null)
    {
        _machine = GetComponent<StateMachine>();
        InitAbility();
        _machine.Init(this);
        _targets = new List<ITarget>();
        _spriteEnemy = GetComponentsInChildren<SpriteRenderer>();
        _targetSearch = GetComponentInChildren<TargetSearch>();
        _targetSearch.OnTargetEnteredEvent += AddTarget;
        _targetSearch.OnTargetExitedEvent += RemoveTarget;
        _health = GetComponent<Health>();
        _health.Init(null);

        if (target != null)
            _targets.Add(target);
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
        Debug.Log("Enemy take damage: " + damage);

        if (_health.CurrentHealth == 0)
        {
            Die();
        }
    }

    private void AddTarget(ITarget target)
    {
        _targets.Add(target);
    }

    private void RemoveTarget(ITarget target)
    {
        for (int i = 0; i < _targets.Count; i++)
        {
            if (_targets[i] == target)
            {
                _targets.RemoveAt(i);
                return;
            }
        }
    }

    private void Die()
    {
        OnDyingEvent?.Invoke();
        OnDyingEvent = null;
        gameObject.SetActive(false);
    }

    private void InitAbility()
    {
        var abilities = GetComponents<Ability>();
        _abilitiesDictionary = new Dictionary<TypeAbility, Ability>();

        foreach (var ability in abilities)
        {
            ability.Init(null);
            _abilitiesDictionary.Add(ability.TypeAbility, ability);
        }
    }
}
