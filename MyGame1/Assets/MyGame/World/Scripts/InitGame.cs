using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private InfoParameters parameters;
    [SerializeField] private GameObject _buttonsConteiner;
    [SerializeField] private Enemy enemy;

    private PlayerParameters _playerParameters;
    private UpgradeSystem _upgradeSystem;
    private ButtonUpgrade[] _buttons;
    private RandomUpgrade _randomUpgrade;

    private void Awake()
    {
        _buttons = _buttonsConteiner.GetComponentsInChildren<ButtonUpgrade>();
        _playerParameters = parameters.CreateStartParameters();
        player.SetParameters(_playerParameters);
        player.Init();
        _upgradeSystem = new UpgradeSystem(parameters, _playerParameters);
        _upgradeSystem.OnUpgrade += player.Init;
        _randomUpgrade = GetComponent<RandomUpgrade>();
        _randomUpgrade.SetUpdateSystem(_upgradeSystem);
        _randomUpgrade.init();


        if(enemy != null)
            enemy.Init();

        foreach (var button in _buttons)
        {
            button.Action += _upgradeSystem.Upgrade;
        }


    }
}
