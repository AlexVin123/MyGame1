using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateStatePositionTarget : State
{
    //public override void Enter()
    //{
    //    base.Enter();
    //    Enemy.PerformAbility(Ability, Enemy.CurrentTarget.Position());
    //}

    private void Update()
    {
        if (Enemy.CurrentTarget != null)
            Enemy.PerformAbility(Ability, Enemy.CurrentTarget.Position);
    }
}
