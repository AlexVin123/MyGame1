using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DistanceTransition<T> : Transition<T> where T : Enemy
{
    [SerializeField] private float _distance;

    public override void ConditionalTest()
    {  
        if (_distance >= Vector2.Distance(Target.transform.position,Enemy.transform.position))
            NeedTransit = true;
    }
}

[CreateAssetMenu(menuName = "Transitions/Test/Distance")]
public class DistanceTransition : DistanceTransition<TestEnemy> { }
