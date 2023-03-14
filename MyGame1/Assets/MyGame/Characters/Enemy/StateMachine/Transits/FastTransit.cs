using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTransit<T> : Transition<T> where T : Enemy
{
    public override void Update()
    {
        NeedTransit = true;
    }
}

namespace EnemyDog
{
    public class FastTransit : FastTransit<EnemyDog> { }
}