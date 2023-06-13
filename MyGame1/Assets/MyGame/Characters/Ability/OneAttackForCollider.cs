using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneAttackForCollider : Ability
{
    [SerializeField] private OneAttackCollider _attackColider;
    [SerializeField] private int _damage;

    public override void Init(ICharacterConfig parameters)
    {
        _attackColider.Init(_damage);
        _attackColider.gameObject.SetActive(false);
    }

    public override void Perform()
    {
        _attackColider.gameObject.SetActive(true);
    }
}
