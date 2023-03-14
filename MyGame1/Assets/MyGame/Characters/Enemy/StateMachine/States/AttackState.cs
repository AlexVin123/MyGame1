using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState<T> : State<T> where T : Enemy
{
    public override void Enter()
    {
        base.Enter();
        Enemy.Attack();
    }
}

namespace EnemyDog
{
public class AttackState : AttackState<EnemyDog> { }
}
