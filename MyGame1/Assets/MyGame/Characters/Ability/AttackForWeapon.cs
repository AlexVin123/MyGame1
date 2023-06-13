using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackForWeapon : Ability
{
    private Weapon _weapon;
    private Aim aim;

    public override void Init(ICharacterConfig parameters)
    {
        aim = GetComponent<Aim>();
        _weapon = GetComponentInChildren<Weapon>();
        _weapon.Init(null);
       //aim.Init(_weapon.gameObject.transform);
    }


    public override void Perform(Vector2 target)
    {
        Vector2 temp = aim.SenderPosition - target;
        aim.AimTarget(temp);
        _weapon.Shoot();
    }
}
