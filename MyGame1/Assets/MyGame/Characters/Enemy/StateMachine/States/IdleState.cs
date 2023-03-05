using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IdleState<T> : State<T> where T : Enemy
{
    public override void Update()
    {
        Check();
    }
}

[CreateAssetMenu(menuName = "State/Test/Idle")]
public class IdleState : IdleState<TestEnemy> { }
