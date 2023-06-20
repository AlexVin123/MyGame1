using System.Collections.Generic;

[System.Serializable]
public class PlayerParameters : ICharacterConfig
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

    public int GetMaxLvlParameter(TypeParameter typeParameter)
    {
        return parametrs.ContainsKey(typeParameter) ? parametrs[typeParameter].MaxLvl : 0;
    }
}

[System.Serializable]
public class Parameter
{
    private string _value;
    private int _lvl;
    private int _maxlvl;

    public string Value => _value;

    public int Level => _lvl;

    public int MaxLvl => _maxlvl; 

    public Parameter(string value, int lvl, int maxLvl)
    {
        _value = value;
        _lvl = lvl;
        _maxlvl = maxLvl;
    }
}
