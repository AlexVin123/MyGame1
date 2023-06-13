using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitState : State
{
    private void Update()
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        Enemy.PerformAbility(TypeAbility.Attack);
    }

    public override void Exit()
    {
        base.Exit();
        Enemy.PerformAbility(TypeAbility.Attack);
    }
}
