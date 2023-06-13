using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryStaminaTransit : Transit
{
    [SerializeField] private Stamina stamina;
    [SerializeField] private Transit _transit2;

    public override void Init(Enemy enemy)
    {
        base.Init(enemy);
        _transit2.Init(enemy);
        _transit2.enabled = true;
    }

    public override bool NeedTransit()
    {
        if(stamina.IsExist && _transit2.NeedTransit())
        {
            _transit2.enabled = false;
            return true;
        }
        else
            return false;
    }
}
