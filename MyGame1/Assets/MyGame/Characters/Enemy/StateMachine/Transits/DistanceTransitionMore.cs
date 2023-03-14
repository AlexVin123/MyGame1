using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DistanceTransitionMore<T> : Transition<T> where T : Enemy
{
    [SerializeField] private float _distance;

    public override void Update()
    {
        if (_distance <= Vector2.Distance(Target.transform.position, Enemy.transform.position))
            NeedTransit = true;
    }
}

namespace EnemyDog
{
public class DistanceTransitionMore : DistanceTransitionMore<EnemyDog> { }
}

