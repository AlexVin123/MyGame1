using UnityEngine;

[RequireComponent(typeof(DefenitionCollisions))]
public abstract class AbstractCollisionTransit : Transit
{
    protected DefenitionCollisions DefenitionCollisions;

    public override void Init(Enemy enemy)
    {
        base.Init(enemy);
        DefenitionCollisions = GetComponent<DefenitionCollisions>();
    }
}
