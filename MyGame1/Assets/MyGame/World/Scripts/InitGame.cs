using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InfoParameters parameters;

    private PlayerParameters _playerParameters;
    private UpgradeParameter _upgradeSystem;
    private RandomUpgrade _randomUpgrade;

    private void Awake()
    {
        _playerParameters = parameters.CreateStartParameters();
        _player.SetParameters(_playerParameters);
        _player.Init();
        _upgradeSystem = new UpgradeParameter(parameters, _playerParameters);
        _upgradeSystem.OnUpgrade += _player.ChaigedParameters;
        _randomUpgrade = GetComponent<RandomUpgrade>();
        _randomUpgrade.SetUpdateSystem(_upgradeSystem);
        _randomUpgrade.init();
        EventSpawner.EndWave += _randomUpgrade.EnableButton;
        EventSpawner.EndSpawn += SceneTransit;
    }

    private void SceneTransit()
    {
        SceneTransition.SwithToScene(1);
    }
}
