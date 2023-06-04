using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateStatePositionTarget : State
{
    private void Update()
    {
        Enemy.PerformAbility(Ability, Enemy.CurrentTarget.Position());
    }

    public override void Enter(Enemy enemy)
    {
        base.Enter(enemy);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
