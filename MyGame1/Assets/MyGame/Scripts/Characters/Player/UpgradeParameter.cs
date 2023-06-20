using UnityEngine.Events;
public class UpgradeParameter
{
    private InfoParameters _infoParameters;
    private PlayerParameters _playerParameters;

    public event UnityAction Upgraded;
    public event UnityAction<TypeParameter> MaxLevelReched; 

    public InfoParameters InfoParameters => _infoParameters;
    public PlayerParameters PlayerParameters => _playerParameters;

    public UpgradeParameter(InfoParameters infoParameters, PlayerParameters playerParameters)
    {
        _infoParameters = infoParameters;
        _playerParameters = playerParameters;
    }

    public void Upgrade(TypeParameter type)
    {
        int currentLvl = _playerParameters.GetlvlParameter(type);
        int nextLvl = ++currentLvl;

        if (nextLvl == _infoParameters.GetMaxLvl(type))
            MaxLevelReched?.Invoke(type);

        if (nextLvl > _infoParameters.GetMaxLvl(type))
            return;

        string value = _infoParameters.GetValue(type, nextLvl);
        Parameter param = new Parameter(value, nextLvl,_infoParameters.GetMaxLvl(type));
        _playerParameters.ReplaceParameter(type, param);
        Upgraded?.Invoke();
    }
}
