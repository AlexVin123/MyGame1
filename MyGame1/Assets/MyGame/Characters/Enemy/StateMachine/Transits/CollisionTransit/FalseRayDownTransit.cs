using UnityEngine;

public class FalseRayDownTransit : AbstractCollisionTransit
{
    [SerializeField] private float _distance;

    public override bool NeedTransit()
    {
        return DefenitionCollisions.ReyCastDown(_distance) == false;
    }
}
