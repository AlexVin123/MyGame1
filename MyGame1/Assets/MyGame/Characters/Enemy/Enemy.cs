using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Enemy : DamageableObject
{
    [SerializeField] private bool _flip;

    private List<ITarget> _targets;
    private Dictionary<TypeAbility, Ability> _abilitiesDictionary;
    private TargetSearch _targetSearch;
    private StateMachine _machine;
    private AnimatorController _controller;
    private Rigidbody2D _rigidbody;

    public Rigidbody2D Rigidbody => _rigidbody;

    public ITarget CurrentTarget
    {
        get
        {
            if (_targets != null && _targets.Count != 0)
            {
                return _targets[_targets.Count - 1];
            }

            return null;
        }
    }




    private void Update()
    {
        //Debug.Log(CurrentTarget);

        if (_flip)
        {
            if (CurrentTarget != null && CurrentTarget.Position.x > transform.position.x)
                transform.rotation = new Quaternion(0, 0, 0, 0);
            else if (CurrentTarget != null && CurrentTarget.Position.x < transform.position.x)
                transform.rotation = new Quaternion(0, 180, 0, 0);
        }


    }

    public override void ResetParam()
    {
        if (_controller != null)
            _machine.ChaigedState = _controller.OnChaigedState;

        _machine.Reset();
        Health.Init();
        _targetSearch.OnTargetEnteredEvent += AddTarget;
        _targetSearch.OnTargetExitedEvent += RemoveTarget;
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

    public override void Init(ICharacterConfig config = null)
    {
        base.Init(config);
        _machine = GetComponent<StateMachine>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _targetSearch = GetComponentInChildren<TargetSearch>();
        _controller = GetComponent<AnimatorController>();
        InitAbility();
        _machine.Init(this);
        _targets = new List<ITarget>();

        if (_controller != null)
        {
            _controller.Init();
            _machine.ChaigedState = _controller.OnChaigedState;
        }
    }

    public void AddTarget(ITarget target)
    {
        if (target != null)
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

    protected override void Die()
    {
        if (_controller != null)
            _machine.ChaigedState -= _controller.OnChaigedState;

        _targetSearch.OnTargetEnteredEvent += AddTarget;
        _targetSearch.OnTargetExitedEvent += RemoveTarget;

        base.Die();
    }

    private void InitAbility()
    {
        var abilities = GetComponents<Ability>();
        _abilitiesDictionary = new Dictionary<TypeAbility, Ability>();

        foreach (var ability in abilities)
        {
            ability.Init(null);
            if (ability.TypeAbility != TypeAbility.None)
                _abilitiesDictionary.Add(ability.TypeAbility, ability);
        }
    }
}
