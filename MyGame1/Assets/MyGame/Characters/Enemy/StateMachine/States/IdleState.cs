using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState<T> : State<T> where T : Enemy
{

}

namespace EnemyDog
{
    public class IdleState : IdleState<EnemyDog> { }
}

