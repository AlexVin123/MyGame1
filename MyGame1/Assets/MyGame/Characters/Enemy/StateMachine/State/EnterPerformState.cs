public class EnterPerformState : State
{
    public override void Enter()
    {
        base.Enter();
        Enemy.PerformAbility(Ability);
    }
}
