public class FalseTargetTransit : Transit
{
    public override bool NeedTransit()
    {
        return Enemy?.CurrentTarget == null;
    }
}
