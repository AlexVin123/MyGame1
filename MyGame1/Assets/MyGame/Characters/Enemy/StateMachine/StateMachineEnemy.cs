using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateMachineEnemy<T> : MonoBehaviour where T : Enemy
{
    [SerializeField] protected List<State<T>> States;
    [SerializeField] private State<T> _startState;

    private T _enemy;
    private GameObject _target;
    private State<T> _currentState;

    public UnityEvent<TypeState> ChaingeState = new UnityEvent<TypeState>();

    public TypeState CurrentState => _currentState.NameState;

    public virtual void Init(T enemy,GameObject target)
    {
        _target = target;
        _enemy = enemy;
        InitState(_enemy,_target);

        if (_currentState == null)
            _currentState = _startState;

        _currentState.Enter();
    }

    public void Update()
    {
        if(_currentState == null)
            return;

        var nexState = _currentState.GetNextState();

        if (nexState != null)
            Transite(nexState);

    }

    protected void InitState(T enemy, GameObject target)
    {
        foreach (var state in States)
        {
            state.Init(enemy,target);
        }
    }

    private void Transite(State<T> nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter();

        ChaingeState?.Invoke(_currentState.NameState);


    }
 }

namespace EnemyDog
{
    public class StateMachineEnemy : StateMachineEnemy<EnemyDog> { }
}
