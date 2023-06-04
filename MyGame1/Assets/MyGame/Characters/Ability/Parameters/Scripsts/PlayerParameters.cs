using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameters : ICharacterParameters
{
    private Dictionary<TypeParameter, Parameter> parametrs;

    public PlayerParameters()
    {
        parametrs = new Dictionary<TypeParameter, Parameter>();
    }

    public string GetValue(TypeParameter typeParameter)
    {
        return parametrs[typeParameter].Value;
    }

    public void AddParameter(TypeParameter typeParameter, Parameter parameter)
    {
        parametrs.Add(typeParameter, parameter);
    }

    public void ReplaceParameter(TypeParameter typeParameter, Parameter newParameter)
    {
        parametrs[typeParameter] = newParameter;
    }

    public int GetlvlParameter(TypeParameter typeParameter)
    {
        return parametrs[typeParameter].Level;
    }
}

[System.Serializable]
public class Parameter
{
    private string _value;
    private int _lvl;

    public string Value => _value;
    public int Level => _lvl;

    public Parameter(string value, int lvl)
    {
        _value = value;
        _lvl = lvl;
    }
}