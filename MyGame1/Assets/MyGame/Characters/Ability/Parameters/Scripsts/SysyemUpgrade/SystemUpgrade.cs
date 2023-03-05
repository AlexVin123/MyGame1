using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemUpgrade
{
    private DataBasePlayer _player;
    private AbilityDataBase _abilityData;

    public SystemUpgrade(DataBasePlayer playerData, AbilityDataBase abilityData)
    {
        _player = playerData;
        _abilityData = abilityData;
    }

    public void Ugrade(TypeParameter type)
    {
        int curentLvlAbility = _player.GetCurrentLvlParameter(type);
        int MaxLvlAbility = _abilityData.GetMaxLvlParameter(type);

        if (curentLvlAbility == MaxLvlAbility)
            return;

        int NextLvl = ++curentLvlAbility;
        _player.Upgrade(_abilityData.GetParameter(type, NextLvl));


    }
}
