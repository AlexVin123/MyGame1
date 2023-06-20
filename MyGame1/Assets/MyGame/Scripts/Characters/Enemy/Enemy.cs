using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimations))]
[RequireComponent(typeof(StateMachine))]
public class Enemy : DamageableObject
{
    [SerializeField] private bool _isFlip;

    private List<ITarget> _targets;
    private Dictionary<TypeAbility, Ability> _abilities;
    private TargetSearch _targetSearch;
    private StateMachine _stateMachine;
    private EnemyAnimations _enemyAnimations;

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
        if (_isFlip)
        {
            if (CurrentTarget != null && CurrentTarget.Position.x > transform.position.x)
                transform.rotation = new Quaternion(0, 0, 0, 0);
            else if (CurrentTarget != null && CurrentTarget.Position.x < transform.position.x)
                transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }

    public void Reset()
    {
        Health.Init(null);

        if (_enemyAnimations != null)
            _stateMachine.ChaigedState += _enemyAnimations.OnChaigeState;

        _stateMachine.Reset();

        if (_targetSearch != null)
        {
            _targetSearch.TargetEntered += OnTargetEnter;
            _targetSearch.TargetExited += OnTargetExit;
        }
    }

    public void Reset(ITarget target)
    {
        if (target != null)
            OnTargetEnter(target);

        Reset();
    }

    public override void Init(ICharacterConfig config)
    {
        base.Init(config);
        _stateMachine = GetComponent<StateMachine>();
        _targetSearch = GetComponentInChildren<TargetSearch>();
        _enemyAnimations = GetComponent<EnemyAnimations>();
        InitAbility();
        _targets = new List<ITarget>();

        if (_enemyAnimations != null)
        {
            _enemyAnimations.Init();
            _stateMachine.ChaigedState += _enemyAnimations.OnChaigeState;
        }

        _stateMachine.Init(this);
    }

    public void PerformAbility(TypeAbility typeAbility)
    {
        _abilities[typeAbility].Perform();
    }

    public void PerformAbility(TypeAbility typeAbility, Vector2 direction)
    {
        _abilities[typeAbility].Perform(direction);
    }

    public void PerformAbility(TypeAbility typeAbility, ITarget target)
    {
        _abilities[typeAbility].Perform(target);
    }

    public void OnTargetEnter(ITarget target)
    {
        if (target != null)
            _targets.Add(target);
    }

    protected override void Die()
    {
        if (_enemyAnimations != null)
            _stateMachine.ChaigedState -= _enemyAnimations.OnChaigeState;

        if (_targetSearch != null)
        {
            _targetSearch.TargetEntered -= OnTargetEnter;
            _targetSearch.TargetExited -= OnTargetExit;

        }

        _targets.Clear();
        base.Die();
    }

    private void OnTargetExit(ITarget target)
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

    private void InitAbility()
    {
        var abilities = GetComponents<Ability>();
        _abilities = new Dictionary<TypeAbility, Ability>();

        foreach (var ability in abilities)
        {
            ability.Init(null);
            if (ability.TypeAbility != TypeAbility.None)
                _abilities.Add(ability.TypeAbility, ability);
        }
    }
}
