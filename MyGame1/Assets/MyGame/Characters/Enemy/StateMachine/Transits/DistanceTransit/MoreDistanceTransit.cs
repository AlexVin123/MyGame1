using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreDistanceTransit : AbstractDistanceTransit
{
    public override bool NeedTransit()
    {
        if (Enemy.CurrentTarget != null)
            return Value < Vector2.Distance(transform.position, Enemy.CurrentTarget.Position);
        else
            return true;
    }
}
