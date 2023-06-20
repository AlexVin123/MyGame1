public class EnterTargetPerformState : State
{
    public override void Enter()
    {
        base.Enter();
        Enemy.PerformAbility(Ability, Enemy.CurrentTarget);
    }
}
