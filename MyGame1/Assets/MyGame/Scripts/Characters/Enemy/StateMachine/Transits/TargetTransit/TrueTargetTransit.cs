public class TrueTargetTransit : Transit
{
    public override bool NeedTransit()
    {
        return Enemy?.CurrentTarget != null;
    }
}


