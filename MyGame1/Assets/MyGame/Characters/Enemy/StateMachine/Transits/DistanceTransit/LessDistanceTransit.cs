using UnityEngine;

public class LessDistanceTransit : AbstractDistanceTransit
{
    public override bool NeedTransit()
    {
        return Value > Vector2.Distance(transform.position, Enemy.CurrentTarget.Position);
    }
}
