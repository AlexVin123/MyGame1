using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class InfoParameter
{
    [SerializeField] private string _name;
    [SerializeField] private TypeParameter _type;
    [SerializeField] private List<string> _values;
    [SerializeField][TextArea(5, 10)] private string _description;

    public string Name => _name;
    public TypeParameter Type => _type;
    public string Description => _description;

    public string GetValue(int lvl)
    {
        if (_values.Count == 0)
        {
            throw new System.ArgumentNullException("Значения для парраметра не назначены");
        }

        return _values[lvl - 1];

    }

    public int GetMaxLvl()
    {
        return _values.Count;
    }
}
