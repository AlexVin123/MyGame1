using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeSystem
{
    private InfoParameters _infoParameters;
    private PlayerParameters _playerParameters;

    public UnityAction OnUpgrade;

    public InfoParameters InfoParameters => _infoParameters;
    public PlayerParameters PlayerParameters => _playerParameters;

    public UpgradeSystem(InfoParameters infoParameters, PlayerParameters playerParameters)
    {
        _infoParameters = infoParameters;
        _playerParameters = playerParameters;
    }

    public void Upgrade(TypeParameter type)
    {
        int currentLvl = _playerParameters.GetlvlParameter(type);
        int nextLvl = ++currentLvl;

        if (nextLvl > _infoParameters.GetMaxLvl(type))
            return;

        string value = _infoParameters.GetValue(type, nextLvl);
        Debug.Log(value +" " + nextLvl);
        Parameter param = new Parameter(value, nextLvl);
        _playerParameters.ReplaceParameter(type, param);
        OnUpgrade?.Invoke();
    }
}
