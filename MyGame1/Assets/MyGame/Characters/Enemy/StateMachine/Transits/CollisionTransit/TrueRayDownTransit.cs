using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueRayDownTransit : AbstractCollisionTransit
{
    [SerializeField] private float _distance;
    public override bool NeedTransit()
    {
        return DefenitionCollisions.ReyCastDown(_distance) == true;
    }
}
