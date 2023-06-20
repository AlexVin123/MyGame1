public class UpdatePerformTargetState : State
{
    private void Update()
    {
        if (Enemy.CurrentTarget != null)
            Enemy.PerformAbility(Ability, Enemy.CurrentTarget);
    }
}
