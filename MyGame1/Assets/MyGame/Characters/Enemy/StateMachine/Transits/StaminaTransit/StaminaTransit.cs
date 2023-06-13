using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stamina))]
public class StaminaTransit : Transit
{
    [SerializeField] private Stamina _stamina;
    [SerializeField] private Transit _transit2;

    public override void Init(Enemy enemy)
    {
        base.Init(enemy);
        _transit2.Init(enemy);
        _transit2.enabled = true;
    }

    public override bool NeedTransit()
    {
       // Debug.Log("Стамина - " + _stamina.IsExist);
       // Debug.Log("Дистанция - " + _transit2.NeedTransit());

        if(_stamina.IsExist && _transit2.NeedTransit())
        {
            _stamina.Spend();
            _transit2.enabled = false;
            return true;
        }

        return false;
    }
}
