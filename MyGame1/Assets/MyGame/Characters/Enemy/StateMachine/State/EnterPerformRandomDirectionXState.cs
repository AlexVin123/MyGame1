using UnityEngine;

public class EnterPerformRandomDirectionXState : State
{
    public override void Enter()
    {
        base.Enter();
        int value = Random.Range(0, 100);
        if (value >= 50)
        {
            Enemy.PerformAbility(Ability, Vector2.left);

        }
        else
        {
            Enemy.PerformAbility(Ability, Vector2.right);
        }
    }
}
