public class ExitPerformState : State
{
    public override void Exit()
    {
        Enemy.PerformAbility(TypeAbility);
        base.Exit();
    }
}
