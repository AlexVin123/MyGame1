using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipState<T> : State<T> where T : Enemy
{
    public override void Init(T enemy, GameObject target)
    {
        base.Init(enemy, target);
    }
    public override void Enter()
    {
        base.Enter();
        Enemy.transform.localScale = new Vector2(Enemy.transform.localScale.x * -1,Enemy.transform.localScale.y);
    }
}

namespace EnemyDog
{
    public class FlipState : FlipState<EnemyDog> { }
}
