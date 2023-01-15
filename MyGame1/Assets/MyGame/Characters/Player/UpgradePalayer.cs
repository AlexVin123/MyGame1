using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePalayer : MonoBehaviour
{
    [SerializeField] private DataBaseAbility _abilitys;
    [SerializeField] private Player _player;

    private DataBasePlayer _dataBasePlayer;

    private void Awake()
    {
        _abilitys.Init();
        _dataBasePlayer = _abilitys.StartParameters();
        _player.SerDataBase(_dataBasePlayer);
        _player.Init();
    }

    public void Upgrade(ParametersPlayer parameter)
    {
        ParameterAbility oldParameter = _dataBasePlayer.GetParameter(parameter);
        int lvl = oldParameter.Lvl + 1;
        ParameterAbility newParameter = _abilitys.GetParameter(lvl,parameter);
        _dataBasePlayer.Upgrade(newParameter);
    }
}
