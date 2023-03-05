using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class LvlParameter<T>
{
    [SerializeField] private TypeParameter _typeParameter;
    [SerializeField] private List<VievParameter<T>> vievParameters;

    public virtual int MaxLvl => _parameters.Count;

    public TypeParameter TypeParameter => _typeParameter; 

    private Dictionary<int, Parameter> _parameters;

    public LvlParameter(Dictionary<int, Parameter> parameters, TypeParameter type)
    {
        _parameters = parameters;
        _typeParameter = type;
    }

    public Parameter GetParameter(int lvl)
    {
        return _parameters[lvl];
    }
}

[System.Serializable]
public class VievParameter<T>
{
    [SerializeField]private T value;

    public T Value => value;
}

