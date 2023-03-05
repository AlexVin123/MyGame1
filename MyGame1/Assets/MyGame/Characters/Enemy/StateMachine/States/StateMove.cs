using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMove<T>: State<T>where T : Enemy
{
    public override void Update()
    {
        Check();
        Enemy.Init();
        Enemy.Move(_target.transform.position); 
    }
}

[CreateAssetMenu(menuName = "State/Test/Move")]
public class StateMove:StateMove<TestEnemy> { }
