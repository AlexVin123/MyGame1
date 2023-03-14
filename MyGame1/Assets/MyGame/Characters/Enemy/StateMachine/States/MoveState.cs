using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState<T>: State<T>where T : Enemy
{
    public override void Init(T enemy, GameObject target)
    {
        base.Init(enemy, target);
    }

    protected override void Update()
    {
        Enemy.Move(GetDirection()); 
    }

    public Vector2 GetDirection()
    {
        if(Target.transform.position.x > Enemy.transform.position.x)
        {
            return new Vector2(1,0);
        }
        else
        {
            return new Vector2(-1,0);
        }
    }
}

namespace EnemyDog
{
    public class MoveState : MoveState<EnemyDog> { }
}
