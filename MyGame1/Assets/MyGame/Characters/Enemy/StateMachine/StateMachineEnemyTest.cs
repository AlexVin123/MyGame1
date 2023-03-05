using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class StateMachineEnemy<T> : ScriptableObject where T : Enemy
{
    [SerializeField]protected List<State<T>> States;
    private T _enemy;
    private GameObject _target;
    [SerializeField]private State<T> _currentState;

    public virtual void Init(T enemy,GameObject target)
    {
        _target = target;
        _enemy = enemy;
        _enemy.Init();
        InitState(_enemy,_target);
        _currentState.Enter();
    }

    protected void InitState(T enemy, GameObject target)
    {
        foreach (var state in States)
        {
            state.Init(enemy,target);
        }
    }

    public void Upgrate()
    {
        if(_currentState == null)
            return;

        var nexState = _currentState.GetNextState();

        if (nexState != null)
            Transite(nexState);

        _currentState.Update();
    }

    private void Transite(State<T> nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter();
    }
 }

[CreateAssetMenu(menuName = ("Create State Machine/Test"))]
public class StateMachineEnemyTest : StateMachineEnemy<TestEnemy> { }
