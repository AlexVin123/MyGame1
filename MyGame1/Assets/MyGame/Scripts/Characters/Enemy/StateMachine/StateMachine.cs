using UnityEngine;
using UnityEngine.Events;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private Enemy _enemy;
    private State _currentState;

    public event UnityAction<TypeState> ChaigedState;

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            StateTransition(nextState);
            ChaigedState?.Invoke(nextState.TypeState);
        }
    }

    public void Reset()
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = _startState;

        if (_currentState != null)
            _currentState.Enter();
    }

    public void Init(Enemy enemy)
    {
        _enemy = enemy;
        InitState();

        if (_currentState == null)
            _currentState = _startState;

        _currentState.Enter();
    }

    private void StateTransition(State nextState)
    {
        _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter();
    }

    private void InitState()
    {
        State[] states = GetComponents<State>();

        foreach (State state in states)
        {
            state.Init(_enemy);
        }
    }
}