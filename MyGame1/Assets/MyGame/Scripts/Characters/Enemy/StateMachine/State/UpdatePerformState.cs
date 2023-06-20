public class UpdatePerformState : State
{
    private void Update()
    {
        Enemy.PerformAbility(Ability);
    }
}

