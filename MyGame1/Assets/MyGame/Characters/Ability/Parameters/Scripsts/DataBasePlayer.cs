using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataBasePlayer: DataBase
{
    public UnityEvent Chainge;

    private Dictionary<TypeParameter, Parameter> _parameters;

    public float MaxSpeed => GetValueFloat(TypeParameter.MaxSpeedMovement);

    public float DictanceBurst => GetValueFloat(TypeParameter.DistanceBurst);

    public float ForgeJump => GetValueFloat(TypeParameter.ForgeJump);

    public float DelayStamina => GetValueFloat(TypeParameter.DelayStamina);

    public int CountStamina => GetValueInt(TypeParameter.CountStamina);

    public int MaxHealth => GetValueInt(TypeParameter.MaxHealth);


    public DataBasePlayer(Dictionary<TypeParameter,Parameter> parameters)
    {
        Chainge = new UnityEvent();
        _parameters = parameters;
    }

    private int GetValueInt(TypeParameter type)
    {
        if(int.TryParse(_parameters[type].Value, out int result))
        {
            return result;
        }
        else
        {
            return 0;
        }
    }

    private float GetValueFloat(TypeParameter type)
    {
        if (float.TryParse(_parameters[type].Value, out float result))
        {
            return result;
        }
        else
        {
            return 0;
        }
    }

    public void Upgrade(Parameter newParameter)
    {
        _parameters[newParameter.TypeParameter] = newParameter;
        Chainge?.Invoke();
    }

    public int GetCurrentLvlParameter(TypeParameter type)
    {
        return _parameters[type].Lvl;
    }

    public override string GetParameter(TypeParameter parameter)
    {
        return _parameters[parameter].Value;
    }
}
