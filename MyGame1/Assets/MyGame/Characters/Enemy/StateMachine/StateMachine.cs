using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private PatternBehavior _patternBehavior;
    [SerializeField] private State _startState;

    private Enemy _enemy;
    private Dictionary<TypeState, State> _dictionaryState;
    private State _currentState;

    public void Init(Enemy enemy)
    {
        _enemy = enemy;
        _patternBehavior.Init();
        SetStates();

        if (_currentState == null)
            _currentState = _startState;

        _currentState.Enter(_enemy);
    }

    private void Update()
    {

        TypeState state = _patternBehavior.GetNextState(_currentState.TypeState, _enemy);

        if (state != TypeState.NotState && _currentState.TypeState != state)
        {
            StateTransition(_dictionaryState[state]);
        }
    }

    private void StateTransition(State nextState)
    {
        _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter(_enemy);
    }

    private void SetStates()
    {
        var states = GetComponents<State>();
        _dictionaryState = new Dictionary<TypeState, State>();

        foreach (var state in states)
        {
            _dictionaryState.Add(state.TypeState, state);
        }
    }
}
