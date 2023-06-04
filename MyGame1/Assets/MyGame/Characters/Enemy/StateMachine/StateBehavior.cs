using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateBehavior
{
    [SerializeField] private TypeState _typeState;
    [SerializeField] private Transit[] _transits;

    public TypeState TypeState => _typeState;

    public TypeState GetNextState(Enemy enemy)
    {
        foreach (var transit in _transits)
        {
            if(transit.NeedTransit(enemy))
            {
                return transit.State;
            }
        }

        return 0;
    }
}
