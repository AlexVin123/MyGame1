using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseAbility: MonoBehaviour
{
    [SerializeField]private List<MovementSpeed> _maxSpeedLvls;
    [SerializeField]private List<DistanceBurst> _distanceBurstLvls;
    [SerializeField] private List<StaminaCount> _staminaCountLvls;
    [SerializeField] private List<StaminaDelay> _staminaDelayLvls;
    [SerializeField] private List<ForgeJump> _forgeJumpLvls;

    private List<ParameterAbility> _allAbility;

    public void Init()
    {
        _allAbility = new List<ParameterAbility>();
        AddInList<MovementSpeed>(_maxSpeedLvls);
        AddInList<DistanceBurst>(_distanceBurstLvls);
        AddInList<StaminaCount>(_staminaCountLvls);
        AddInList<StaminaDelay>(_staminaDelayLvls);
        AddInList<ForgeJump>(_forgeJumpLvls);
    }


    private void AddInList<T>(List<T> abillities) where T : ParameterAbility
    {
        Debug.Log("Добавлен лист: " + abillities.GetType());

        foreach (var abillity in abillities)
        {
            _allAbility.Add(abillity);
        }
    }    


    public DataBasePlayer StartParameters()
    {
        DataBasePlayer player = new DataBasePlayer();

        if(_allAbility == null)
        {
            throw new Exception("Лист способностей пуст");
        }

        for (int i = 0; i < _allAbility.Count; i++)
        {
            if (_allAbility[i].Lvl == 0)
            {
                player.AddParameter(_allAbility[i]);
            }
        }
        return player;
    }

    public ParameterAbility GetParameter(int lvl, ParametersPlayer parameter)
    {
        foreach (ParameterAbility abillty in _allAbility)
        {
            if(abillty.Lvl == lvl && abillty.TypeParameter == parameter)
                return abillty;
        }

        return null;
    }
}

public abstract class ParameterAbility
{
    [SerializeField]private int _lvl;

    public abstract ParametersPlayer TypeParameter { get;}

    public int Lvl => _lvl;

    public abstract float Value { get; }
}

[Serializable]
public class MovementSpeed : ParameterAbility
{
    [SerializeField] private float _maxSpeed;

    public override float Value => _maxSpeed;

    public override ParametersPlayer TypeParameter { get => ParametersPlayer.MaxSpeed; }
}

[Serializable]
public class DistanceBurst : ParameterAbility
{
    [SerializeField] private float _distance;

    public override float Value => _distance;

}

[Serializable]
public class ForgeJump : ParameterAbility
{
    [SerializeField] private float _forgeJump;

    public override float Value => _forgeJump;
}

[Serializable]
public class StaminaCount : ParameterAbility
{
    [SerializeField] private float _count;

    public override float Value => _count;
}

[Serializable]
public class StaminaDelay : ParameterAbility
{
    [SerializeField] private float _delay;

    public override float Value => _delay;
}
