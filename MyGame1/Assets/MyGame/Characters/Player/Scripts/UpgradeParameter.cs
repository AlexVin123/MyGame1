using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UpgradeParameter
{
    private InfoParameters _infoParameters;
    private PlayerParameters _playerParameters;

    public UnityAction Upgraded;
    public UnityAction<TypeParameter> MAXLVL; 

    public InfoParameters InfoParameters => _infoParameters;
    public PlayerParameters PlayerParameters => _playerParameters;

    public UpgradeParameter(InfoParameters infoParameters, PlayerParameters playerParameters)
    {
        _infoParameters = infoParameters;
        _playerParameters = playerParameters;
    }

    public void Upgrade(TypeParameter type)
    {
        Debug.Log("Oбнова2");

        int currentLvl = _playerParameters.GetlvlParameter(type);
        int nextLvl = ++currentLvl;

        if (nextLvl == _infoParameters.GetMaxLvl(type))
            MAXLVL?.Invoke(type);

        if (nextLvl > _infoParameters.GetMaxLvl(type))
            return;

        string value = _infoParameters.GetValue(type, nextLvl);
        Debug.Log(value +" " + nextLvl);
        Parameter param = new Parameter(value, nextLvl,_infoParameters.GetMaxLvl(type));
        _playerParameters.ReplaceParameter(type, param);
        Upgraded?.Invoke();
    }
}
