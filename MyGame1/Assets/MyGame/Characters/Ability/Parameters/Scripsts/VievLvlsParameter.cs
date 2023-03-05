using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VievLvlsParameter<T> : ScriptableObject
{
    [SerializeField] private TypeParameter _type;
    [SerializeField] private List<VievParameter<T>> _parameters;

    public TypeParameter Type => _type;

    private Parameter CreateParameter(int lvl, string value)
    {
        return new Parameter(lvl, _type, value);
    }

    public virtual LvlParameter<string> CreateString()
    {
        Dictionary<int, Parameter> parameters = new Dictionary<int, Parameter>();

        for (int i = 0; i < _parameters.Count; i++)
        {
            parameters.Add(i + 1, CreateParameter(i + 1, _parameters[i].Value.ToString()));
        }

        LvlParameter<string> par = new LvlParameter<string>(parameters,_type);

        Debug.Log(par);

        return par;
    }
}

[CreateAssetMenu(menuName = "Create/int")]
public class VievLvlParameterInt : VievLvlsParameter<int> 
{
    public override LvlParameter<string> CreateString() => base.CreateString();
}
[CreateAssetMenu (menuName = "Create/float")]
public class VievLvlParameterFloat : VievLvlsParameter<float> 
{
    public override LvlParameter<string> CreateString() => base.CreateString();
}
