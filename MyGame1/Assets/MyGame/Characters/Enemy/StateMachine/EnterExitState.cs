using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitState : State
{
    private void Update()
    {
        
    }

    public override void Enter(Enemy enemy)
    {
        base.Enter(enemy);
        Enemy.PerformAbility(TypeAbility.Abillity1);
    }

    public override void Exit()
    {
        base.Exit();
        Enemy.PerformAbility(TypeAbility.Abillity1);
    }
}
