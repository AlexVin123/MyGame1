using System.Collections.Generic;
using UnityEngine;

public class PanelUpgrade : Menu
{
    [SerializeField] private ButtonUpgrade[] _buttons;
    private List<TypeParameter> _typeParameters;
    private List<TypeParameter> _randomParametersForButton;
    private UpgradeParameter _upgradeSystem;

    private void OnEnable()
    {
        InitButton();
        Subscribe();
    }

    private void OnDisable()
    {
        _randomParametersForButton = new List<TypeParameter>();
        UnSubscribe();
    }

    public void init()
    {
        _typeParameters = new List<TypeParameter>();

        foreach (var typeParameter in System.Enum.GetValues(typeof(TypeParameter)))
            _typeParameters.Add((TypeParameter)typeParameter);
    }

    public void SetUpdateSystem(UpgradeParameter upgrade)
    {
        _upgradeSystem = upgrade;
    }

    private List<TypeParameter> Clone()
    {
        List<TypeParameter> clone = new List<TypeParameter>();

        foreach (TypeParameter typeParameter in _typeParameters)
            clone.Add(typeParameter);

        return clone;
    }

    private void CreateRandom()
    {
        List<TypeParameter> temp = Clone();
        _randomParametersForButton = new List<TypeParameter>();

        for (int i = 0; i < _buttons.Length; i++)
        {
            if (temp.Count == 0)
                return;

            int index = Random.Range(0, temp.Count);
            _randomParametersForButton.Add(temp[index]);
            temp.RemoveAt(index);
        }
    }

    private void Subscribe()
    {
        _upgradeSystem.MaxLevelReched += OnMaxLevelRech;

        foreach (var button in _buttons)
        {
            button.Updated += _upgradeSystem.Upgrade;
            button.Cliked += Clouse;
        }
    }

    private void UnSubscribe()
    {
        _upgradeSystem.MaxLevelReched -= OnMaxLevelRech;

        foreach (var button in _buttons)
        {
            button.Updated -= _upgradeSystem.Upgrade;
            button.Cliked -= Clouse;
        }
    }

    private void InitButton()
    {
        CreateRandom();
        for (int i = 0; i < _buttons.Length; i++)
            _buttons[i].Init(_randomParametersForButton[i], _upgradeSystem.InfoParameters.GetSprite(_randomParametersForButton[i]));
    }

    private void OnMaxLevelRech(TypeParameter typeParameter)
    {
        for (int i = 0; i < _typeParameters.Count; i++)
        {
            if (_typeParameters[i] == typeParameter)
                _typeParameters.RemoveAt(i);
        }
    }
}
