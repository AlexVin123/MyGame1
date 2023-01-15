using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBasePlayer
{
    private List<ParameterAbility> _parameters = new List<ParameterAbility>();

    public void AddParameter(ParameterAbility parameter)
    {
        _parameters.Add(parameter);
    }

    public ParameterAbility GetParameter(ParametersPlayer parameter)
    {
        Debug.Log("Игрок" + _parameters.Count);
        foreach (ParameterAbility ability in _parameters)
        {
            if(ability.TypeParameter == parameter)
                return ability;
            else
                return null;
        }
        return null;
    }

    public void Upgrade(ParameterAbility newAbility)
    {
        for (int i = 0; i < _parameters.Count; i++)
        {
            if(_parameters[i].GetType() == newAbility.GetType())
            {
                _parameters[i] = newAbility;
                return;
            }
        }
    }
}
