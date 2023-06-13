using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterState : State
{
    private void Update()
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        Enemy.PerformAbility(Ability);
    }
}
