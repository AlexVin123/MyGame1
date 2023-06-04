using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/CreatePatternBehavior")]
public class PatternBehavior : ScriptableObject
{
    [SerializeField] private StateBehavior[] _states;

    private Dictionary<TypeState, StateBehavior> _disctionaryStates;

    public void Init()
    {
        if (_disctionaryStates == null)
        {
            _disctionaryStates = new Dictionary<TypeState, StateBehavior>();

            foreach (var state in _states)
            {
                _disctionaryStates.Add(state.TypeState, state);
            }
        }
    }

    public TypeState GetNextState(TypeState curretState, Enemy enemy)
    {
        return _disctionaryStates[curretState].GetNextState(enemy);
    }

}
