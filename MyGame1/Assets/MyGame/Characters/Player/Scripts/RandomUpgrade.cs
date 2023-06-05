using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomUpgrade : MonoBehaviour
{
    [SerializeField] private int _countRandom = 3;
    [SerializeField] private ButtonUpgrade[] _buttons;
    [SerializeField] private Spawner _spawner;
    private List<TypeParameter> typeParameters;
    private List<TypeParameter> random = new List<TypeParameter>();
    private UpgradeParameter _upgradeSystem;

    public void init()
    {
        typeParameters = new List<TypeParameter>();

     foreach (var typeParameter in System.Enum.GetValues(typeof(TypeParameter)))
        {
            typeParameters.Add((TypeParameter)typeParameter);
        }

        EnableButton();
    }

    public void SetUpdateSystem(UpgradeParameter upgrade)
    {
        _upgradeSystem = upgrade;
    }

    private void CreateRandom()
    {
        List<TypeParameter> temp = typeParameters;

        for(int i = 0; i < _countRandom; i++)
        {
            if (temp.Count == 0)
                return;

            int index = Random.Range(0, temp.Count);
            random.Add(temp[index]);
            temp.RemoveAt(index);
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

    public void EnableButton()
    {
        InitButton();

       foreach(var button in _buttons)
        {
            button.gameObject.SetActive(true);
            button.Action += _upgradeSystem.Upgrade;
            button.Button.onClick.AddListener(_spawner.SpawnEnemyInPoints);
            button.Button.onClick.AddListener(DisableButton);
        }
    }

    private void DisableButton()
    {
        foreach(var button in _buttons)
        {
            button.Action -= _upgradeSystem.Upgrade;
            button.gameObject.SetActive(false);
        }
    }
}
