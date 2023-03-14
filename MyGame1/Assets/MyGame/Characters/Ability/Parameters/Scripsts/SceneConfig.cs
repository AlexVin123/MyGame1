using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneConfig : MonoBehaviour
{
    public static Vector2 PoasitionPlayer { get; private set; }
    [SerializeField] private Player _player;
    [SerializeField] private AbilityDataBase _abilityDataBase;
    [SerializeField] private List<ButtonUpgrate> buttons;
    [SerializeField] private Bar _healthBar;
    [SerializeField] private StaminaUI _staminaUI;

    private DataBasePlayer _playerData;
    private SystemUpgrade systemUpgrade;

    private void Awake()
    {
        _abilityDataBase.Init();
        _playerData = _abilityDataBase.CreateDataBasePlayer();
        _player.SetDataBase(_playerData);
        _player.Init();
        _staminaUI.Init(int.Parse(_playerData.GetParameter(TypeParameter.CountStamina)));
        systemUpgrade = new SystemUpgrade(_playerData, _abilityDataBase);
        ButtonInit();
        PoasitionPlayer = _player.transform.position;
    }

    private void ButtonInit()
    {
        foreach (var button in buttons)
        {
            button.Init(systemUpgrade);
        }
    }
}
