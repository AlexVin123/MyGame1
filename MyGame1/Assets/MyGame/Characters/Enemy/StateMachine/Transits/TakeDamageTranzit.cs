using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageTranzit : Transit
{
    private bool IsTakedDameg = false;

    public override void Init(Enemy enemy)
    {
        base.Init(enemy);
        IsTakedDameg = false;
        Enemy.TakedDamage = OnTekeDamage;
    }

    public override bool NeedTransit()
    {
        return IsTakedDameg;

    }

    private void OnTekeDamage()
    {
        IsTakedDameg = true;
    }

    private void OnEnable()
    {
        if (Enemy != null)
            Enemy.TakedDamage = OnTekeDamage;
    }

    private void OnDisable()
    {
        if (Enemy != null)
            Enemy.TakedDamage -= OnTekeDamage;
    }
}
