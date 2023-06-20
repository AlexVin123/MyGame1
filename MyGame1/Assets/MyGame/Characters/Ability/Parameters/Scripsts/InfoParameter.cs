using UnityEngine;

[System.Serializable]
public class InfoParameter
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private TypeParameter _type;
    [SerializeField] private string[] _values;

    public Sprite Sprite => _sprite;
    public TypeParameter Type => _type;

    public string GetValue(int lvl)
    {
        if (_values.Length == 0)
        {
            throw new System.ArgumentNullException("Значения для парраметра не назначены");
        }

        return _values[lvl - 1];

    }

    public int GetMaxLvl()
    {
        return _values.Length;
    }
}
