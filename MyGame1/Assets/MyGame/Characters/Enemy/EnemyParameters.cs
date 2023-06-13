using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateEnemyParameters")]
public class EnemyParameters : ScriptableObject, ICharacterConfig
{
    [SerializeField] private List<EnemyParameter> _enemyParameters;

    public string GetValue(TypeParameter parameter)
    {
        foreach (EnemyParameter enemyParameter in _enemyParameters)
        {
            if (enemyParameter.TypeParameter == parameter)
                return enemyParameter.Value.ToString();
        }

        return 0f.ToString();
    }
}

[System.Serializable]
public class EnemyParameter
{
    [SerializeField] private TypeParameter _typeParameter;
    [SerializeField] private float _value;

    public TypeParameter TypeParameter => _typeParameter;

    public float Value => _value;
}
