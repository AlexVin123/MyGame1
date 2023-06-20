public class MoreDistanceTransitX : AbstractDistanceTransit
{
    public override bool NeedTransit()
    {
        float distance = transform.position.x - Enemy.CurrentTarget.Position.x;

        if (distance < 0)
            distance *= -1;

        return Value < distance;
    }
}
