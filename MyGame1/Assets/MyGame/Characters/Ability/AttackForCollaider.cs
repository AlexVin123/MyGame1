using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackForCollaider : Ability
{
    [SerializeField] private float _speedAttack;
    [SerializeField] private int _damage;

    private AttackCollaider _collaider;
    public override void Init(ICharacterParameters parameters = null)
    {
        if (parameters != null)
        {
            if (int.TryParse(parameters.GetValue(TypeParameter.MaxSpeedMovement), out int result))
                _damage = result;
            else
                throw new System.FormatException("Конвертация не возможна, измените параметер на int");
        }

        _collaider = GetComponentInChildren<AttackCollaider>();
        _collaider.Init(_damage, _speedAttack);
        _collaider.gameObject.SetActive(false);
    }

    public override void Perform()
    {
        if (_collaider.gameObject.activeInHierarchy == false)
            _collaider.gameObject.SetActive(true);
        else
            _collaider.gameObject.SetActive(false);
    }
}
