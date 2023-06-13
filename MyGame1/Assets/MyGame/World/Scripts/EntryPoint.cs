using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InfoParameters parameters;
    [SerializeField] private PanelUpgrade _randomUpgrade;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Menu _menu;
    [SerializeField] private SpawnerUI _spawnerUI;
    [SerializeField] private Bar _healthPlayer;
    [SerializeField] private StaminaUI _staminaPlayer;
    [SerializeField] private Bar _targerBar;
    [SerializeField] private DamageableObject _firstTarget;
    [SerializeField] private DamageableObject[] _damageableObjects;

    private PlayerParameters _playerParameters;
    private UpgradeParameter _upgradeSystem;
    private PlayerInputController _playerInputController;

    private void Start()
    {
        _playerInputController = _player.gameObject.GetComponent<PlayerInputController>();
        _playerParameters = parameters.CreateStartParameters();
        _upgradeSystem = new UpgradeParameter(parameters, _playerParameters);
        _player.Init(_playerParameters);
        _randomUpgrade.SetUpdateSystem(_upgradeSystem);

        _playerInputController.Init();
        _spawnerUI.Init(_spawner);
        _firstTarget.Init();
        _staminaPlayer.Init(_player.CountStamina);
        Subscribe();

        _spawner.Init();

        _randomUpgrade.init();
        _randomUpgrade.Open();

        if(_damageableObjects != null)
        {
            foreach (var damageableObject in _damageableObjects)
            {
                damageableObject.Init();
            }
        }



    }

    private void OnDisable()
    {
        UnSubscribe();
    }

    private void Subscribe()
    {
        _playerInputController.Input.PlayerController.OpenMenu.performed += _menu.OpenClouse;

        _randomUpgrade.PanelCloused += _spawner.SpawnEnemyInPoints;
        _randomUpgrade.PanelCloused += _playerInputController.OnClousedPanel;
        _randomUpgrade.PanelOpen += _playerInputController.OnOpenPanel;

        _spawner.EndWave += _randomUpgrade.Open;
        _spawner.EndSpawn += SceneTransit;
        _spawner.ChaigedWave += _spawnerUI.OnChaigeWave;
        _spawner.ChaigedWaveProgress += _spawnerUI.OnChangeProgressWave;

        _upgradeSystem.Upgraded += _player.OnUpgradeParameter;

        _menu.PanelOpen += _playerInputController.OnOpenPanel;
        _menu.PanelCloused += _playerInputController.OnClousedPanel;

        _player.AddedStaminaCount += _staminaPlayer.OnAddedStaminaPoint;
        _player.ChaigedStaminaCount += _staminaPlayer.OnChaingeCount;
        _player.ChaigeLoadStaminaPoint += _staminaPlayer.OnLoadStaminaPoint;
        _player.ChaigedHealth += _healthPlayer.ChaingeBar;

        _firstTarget.ChaigedHealth += _targerBar.ChaingeBar;
    }

    private void UnSubscribe()
    {
        _spawner.EndWave -= _randomUpgrade.Open;
        _spawner.EndSpawn -= SceneTransit;
        _spawner.ChaigedWave -= _spawnerUI.OnChaigeWave;
        _spawner.ChaigedWaveProgress -= _spawnerUI.OnChangeProgressWave;

        _randomUpgrade.PanelCloused -= _spawner.SpawnEnemyInPoints;
        _randomUpgrade.PanelOpen -= _playerInputController.OnOpenPanel;
        _randomUpgrade.PanelCloused -= _playerInputController.OnClousedPanel;

        _playerInputController.Input.PlayerController.OpenMenu.performed -= _menu.OpenClouse;

        _upgradeSystem.Upgraded -= _player.OnUpgradeParameter;

        _menu.PanelOpen -= _playerInputController.OnOpenPanel;
        _menu.PanelCloused -= _playerInputController.OnClousedPanel;

        _player.AddedStaminaCount -= _staminaPlayer.OnAddedStaminaPoint;
        _player.ChaigedStaminaCount -= _staminaPlayer.OnChaingeCount;
        _player.ChaigeLoadStaminaPoint -= _staminaPlayer.OnLoadStaminaPoint;
        _player.ChaigedHealth -= _healthPlayer.ChaingeBar;

        _firstTarget.ChaigedHealth -= _targerBar.ChaingeBar;
    }

    private void SceneTransit()
    {
        SceneTransition.SwithToScene(1);
    }
}