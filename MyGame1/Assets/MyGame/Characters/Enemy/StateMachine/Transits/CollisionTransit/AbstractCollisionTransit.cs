using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCollisionTransit : Transit
{
    protected DefenitionCollisions DefenitionCollisions;

    public override void Init(Enemy enemy)
    {
        base.Init(enemy);
        DefenitionCollisions = Enemy.gameObject.GetComponent<DefenitionCollisions>();
    }
}
