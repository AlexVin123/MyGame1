using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessDistanceTransitX : AbstractDistanceTransit
{
    public override bool NeedTransit()
    {
        float distance = transform.position.x - Enemy.CurrentTarget.Position.x;

        if (distance < 0)
            distance *= -1;

        return Value > distance;
    }
}
