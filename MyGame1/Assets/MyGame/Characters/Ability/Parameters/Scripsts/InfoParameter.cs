using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class InfoParameter
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private TypeParameter _type;
    [SerializeField] private List<string> _values;

    public Sprite Sprite => _sprite;
    public TypeParameter Type => _type;

    public string GetValue(int lvl)
    {
        if (_values.Count == 0)
        {
            throw new System.ArgumentNullException("�������� ��� ���������� �� ���������");
        }

        return _values[lvl - 1];

    }

    public int GetMaxLvl()
    {
        return _values.Count;
    }
}
