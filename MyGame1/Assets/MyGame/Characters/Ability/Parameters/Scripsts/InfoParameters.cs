using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Info Parameters", fileName = "New Info Paramers")]
public class InfoParameters : ScriptableObject
{
    [SerializeField] private List<InfoParameter> _parameters;

    public InfoParameter GetInfo(TypeParameter type)
    {
        foreach (var parameter in _parameters)
        {
            if (parameter.Type == type)
                return parameter;
        }

        throw new System.ArgumentException("Тип параметра отсутствует");
    }

    public string GetValue(TypeParameter type, int lvl)
    {
        foreach (var parameter in _parameters)
        {
            if (parameter.Type == type)
                return parameter.GetValue(lvl);
        }

        throw new System.ArgumentException("Тип параметра отсутствует");
    }

    public int GetMaxLvl(TypeParameter type)
    {
        foreach (var parameter in _parameters)
        {
            if (parameter.Type == type)
                return parameter.GetMaxLvl();
        }

        return 0;
    }

    public Sprite GetSprite(TypeParameter type)
    {
        foreach (var parameter in _parameters)
        {
            if (parameter.Type == type)
                return parameter.Sprite;
        }

        return null;
    }

    public PlayerParameters CreateStartParameters()
    {
        PlayerParameters parameters = new PlayerParameters();
        int startLvl = 1;

        foreach (var parameter in _parameters)
        {
            Parameter tempParam = new Parameter(parameter.GetValue(startLvl),startLvl,parameter.GetMaxLvl());
            parameters.AddParameter(parameter.Type, tempParam);
        }

        return parameters;
    }
}
