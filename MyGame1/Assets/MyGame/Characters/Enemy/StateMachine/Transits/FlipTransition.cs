using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTransition<T> : Transition<T> where T : Enemy
{
    private bool _right = true;

    public override void Update()
    {
        if(Enemy.transform.position.x > Target.transform.position.x && _right == false)
        {
            _right = true;
            NeedTransit = true;
        }
        else if(Enemy.transform.position.x < Target.transform.position.x && _right == true)
        {
            _right = false;
            NeedTransit = true;
        }
    }
}

namespace EnemyDog
{
    public class FlipTransition : FlipTransition<EnemyDog> { }
}
