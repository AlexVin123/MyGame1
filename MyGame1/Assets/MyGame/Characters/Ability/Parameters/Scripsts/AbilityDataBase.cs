using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Database Ability")]
public class AbilityDataBase:ScriptableObject
{
    [SerializeField]private List<VievLvlParameterInt> _intParameters;
    [SerializeField] private List<VievLvlParameterFloat> _floatParameters;

    private List<LvlParameter<string>> _parameters = new List<LvlParameter<string>>();
    public void Init()
    {
        foreach(var p in _intParameters)
        {
            _parameters.Add(p.CreateString());
          }

        foreach(var t in _floatParameters)
        {
            _parameters.Add(t.CreateString());
        }

        Debug.Log("f");

        foreach (var param in _parameters)
        {
            Debug.Log("FFFF"+ param.TypeParameter);
        }
    }

    private void ConvertParameters<T,B>(List<T> parameters) where T : VievLvlsParameter<B>
    {
        foreach (var param in parameters)
        {
            _parameters.Add(param.CreateString());
        }
    }

    public DataBasePlayer CreateDataBasePlayer()
    {
        Dictionary<TypeParameter, Parameter> parameters = new Dictionary<TypeParameter, Parameter>();

        foreach(LvlParameter<string> parameter in _parameters)
        {
            parameters.Add(parameter.TypeParameter, parameter.GetParameter(1));
        }

        return new DataBasePlayer(parameters);
    }

    public int GetMaxLvlParameter(TypeParameter type)
    {
        foreach(LvlParameter<string> parameter in _parameters)
        {
            if (parameter.TypeParameter == type)
                return parameter.MaxLvl;
        }

        Debug.Log("No parameter");

        return 0;
    }

    public Parameter GetParameter(TypeParameter type, int lvl)
    {
        foreach(var param in _parameters)
        {
            if (param.TypeParameter == type)
                return param.GetParameter(lvl);
        }

        return null;
    }

}
