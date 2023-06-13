using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[System.Serializable]
public class PanelUpgrade : Menu
{
    [SerializeField] private ButtonUpgrade[] _buttons;
    private List<TypeParameter> typeParameters;
    private List<TypeParameter> random;
    private UpgradeParameter _upgradeSystem;

    private void OnEnable()
    {

        InitButton();
        Subscribe();
    }

    private void OnDisable()
    {
        random = new List<TypeParameter>();
        UnSubscribe();
    }

    public void init()
    {
        typeParameters = new List<TypeParameter>();

     foreach (var typeParameter in System.Enum.GetValues(typeof(TypeParameter)))
        {
            typeParameters.Add((TypeParameter)typeParameter);
        }
    }

    public void SetUpdateSystem(UpgradeParameter upgrade)
    {
        _upgradeSystem = upgrade;
    }

    private List<TypeParameter> Clone()
    {
        List<TypeParameter> clone = new List<TypeParameter>();

        foreach(TypeParameter typeParameter in typeParameters)
        {
            clone.Add(typeParameter);
        }

        return clone;
    }

    private void CreateRandom()
    {
        List<TypeParameter> temp = Clone();
        random = new List<TypeParameter>();

        for (int i = 0; i < _buttons.Length; i++)
        {
            if (temp.Count == 0)
                return;

            int index = Random.Range(0, temp.Count);
            random.Add(temp[index]);
            temp.RemoveAt(index);
        }
    }

    private void Subscribe()
    {
        _upgradeSystem.MAXLVL += OnMaxLevelRech;

        foreach (var button in _buttons)
        {
            button.Updated += _upgradeSystem.Upgrade;
            button.Cliked += Clouse;
        }
    }

    private void UnSubscribe()
    {
        _upgradeSystem.MAXLVL -= OnMaxLevelRech;

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
        {
            _buttons[i].Init(random[i], _upgradeSystem.InfoParameters.GetSprite(random[i]));
        }
    }

    private void OnMaxLevelRech(TypeParameter typeParameter)
    {
        for (int i = 0; i < typeParameters.Count; i++)
        {
            if(typeParameters[i] == typeParameter)
                typeParameters.RemoveAt(i);
        }
    }
}
